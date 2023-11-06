using huce.motcua.repository;
using huce.phuhuynh.entities.Context;
using huce.phuhuynh.entities.Dto;
using huce.phuhuynh.entities.Models;
using huce.phuhuynh.lib;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.repositories
{
    public class UsersRepository : BaseRepository<Users>
    {
        public UsersRepository(HucePhuHuynhDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        /// <summary>
        /// Check mssv + pwd. Đúng thì trả về thông tin sinh viên
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Users ValidateUser(ValidatePasswordDto dto)
        {
            var dbPassword = CommonUtils.CreateMD5(dto.Password);

            var userQuery = from users in _dbContext.Users
                                where users.Username == dto.Username && users.Password == dbPassword
                                select users;
            return userQuery.FirstOrDefault();
        }
    }
}
