using huce.phuhuynh.entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.domain.Interfaces
{
    public interface IUserServices
    {
        bool ValidatePassword(ValidatePasswordDto dto);
        Task<List<Claim>> GetSvClaims(string masv);
    }
}
