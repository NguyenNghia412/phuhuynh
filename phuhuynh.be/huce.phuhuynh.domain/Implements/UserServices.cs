using AutoMapper;
using huce.phuhuynh.domain.Interfaces;
using huce.phuhuynh.entities.Context;
using huce.phuhuynh.entities.Dto;
using huce.phuhuynh.lib;
using huce.phuhuynh.lib.ExceptionCustom;
using huce.phuhuynh.lib.User;
using huce.phuhuynh.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.domain.Implements
{
    public class UserServices : IUserServices
    {
        private readonly ILogger<UserServices> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly HucePhuHuynhDbContext _dbContext;
        private readonly ICdsServices _cdsServices;
        private readonly UsersRepository _userRepository;
        //private readonly IMapper _mapper;

        public UserServices(
            ILogger<UserServices> logger,
            IHttpContextAccessor httpContext,
            ICdsServices cdsServices,
            HucePhuHuynhDbContext dbContext
            //IMapper mapper
        )
        {
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;
            _cdsServices = cdsServices;
            _userRepository = new UsersRepository(dbContext, logger);
            //_mapper = mapper;
        }
    
        /// <summary>
        ///  Lấy claims cho sv đăng nhập
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<List<Claim>> GetSvClaims(string masv)
        {
            var result = new List<Claim>();
            var sv = await _cdsServices.GetSinhVienByMasvAsync(masv);

            if (sv == null)
            {
                _logger.LogError($"Không tìm thấy sinh viên {masv}");
                throw new CustomException($"Không tìm thấy sinh viên {masv}.", ERROR_CODES.USER_NOT_EXISTS);
            }

            //result.Add(new Claim(CustomClaimTypes.UserType, UserTypes.SINH_VIEN));
            result.Add(new Claim(CustomClaimTypes.UserName, masv));
            result.Add(new Claim(CustomClaimTypes.DisplayName, $"{sv.hoDem} {sv.ten}"));

            return result;
        }

        /// <summary>
        /// Check mssv + pwd. Đúng thì trả về thông tin sinh viên
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool ValidatePassword(ValidatePasswordDto dto)
        {
            var userValider = _userRepository.ValidateUser(dto);
            if(userValider != null)
            {
                return true;
            }
            return false;
        }
    }
}
