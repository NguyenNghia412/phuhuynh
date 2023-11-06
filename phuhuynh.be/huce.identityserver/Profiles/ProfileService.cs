using huce.phuhuynh.domain.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace huce.phuhuynh.identityserver.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IUserServices _userServices;
        public ProfileService(
            ILogger<ProfileService> logger,
            IUserServices userServices
        )
        {
            _logger = logger;
            _userServices = userServices;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // lấy username
            var username = context.Subject.FindFirst("sub").Value;
            if (username == null)
            {
                _logger.LogError("Profile sinh vien => subject null");
            }

            //add claims
            var claims = await _userServices.GetSvClaims(username);
            context.IssuedClaims.AddRange(claims);

            /*// lấy usertype
            var usertype = context.Subject.FindFirst(CustomClaimTypes.UserType)?.Value;
            if (usertype == UserTypes.SINH_VIEN)
            {
                // add claims
                var claims = await _userServices.GetSvClaims(username);
                context.IssuedClaims.AddRange(claims);
            }
            else if (usertype == UserTypes.CAN_BO)
            {
                // add claims
                var claims = await _userServices.GetCanBoClaims(username);
                context.IssuedClaims.AddRange(claims);
            }*/
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
