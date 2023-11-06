using huce.phuhuynh.domain.Interfaces;
using huce.phuhuynh.lib;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace huce.phuhuynh.identityserver.GrantValidators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private readonly IEventService _events;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly ICDSConnectServices _cdsConnectServices;
        private readonly IUserServices _userServices;

        public ResourceOwnerPasswordValidator(
            IEventService events,
            IConfiguration configuration,
            ILogger<ResourceOwnerPasswordValidator> logger,
            IHttpContextAccessor httpContextAccessor,
            //ICDSConnectServices cdsConnectServices,
            IUserServices userServices
        )
        {
            _events = events;
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            //_cdsConnectServices = cdsConnectServices;
            _userServices = userServices;
        }

        /// <summary>
        /// Đăng nhập phụ huynh
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _logger.LogInformation("ipaddress request password grant: {}", ipAddress);

            context.UserName = context.UserName?.Trim();
            context.Password = context.Password?.Trim();
            var loginSuccess = _userServices.ValidatePassword(new entities.Dto.ValidatePasswordDto { Username = context.UserName, Password = context.Password });

            if (!loginSuccess)
            {
                _logger.LogInformation("No user found matching username: {username}", context.UserName);

                await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "invalid username", interactive: false));
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid username",
                    new Dictionary<string, object>()
                    {
                        { CustomResponseKey.CODE, ERROR_CODES.USER_LOGIN_USERNAME_OR_PASSWORD_NOT_RIGHT },
                        { CustomResponseKey.MESSAGE, "Tài khoản hoặc mật khẩu không chính xác" }
                    });
            }
            else
            {
                _logger.LogInformation("Credentials validated for username: {username}", context.UserName);
                /*var claims = new List<Claim>
                {
                    new Claim(CustomClaimTypes.UserType, UserTypes.SINH_VIEN),
                };
*/
                context.Result = new GrantValidationResult(context.UserName, AuthenticationMethods.Password);
                return;
            }
        }
    }
}
