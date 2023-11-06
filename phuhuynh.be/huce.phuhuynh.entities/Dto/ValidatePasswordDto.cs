using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.entities.Dto
{
    public class ValidatePasswordDto
    {
        private string _usename { get; set; }
        private string _password { get; set; }

        /// <summary>
        /// Mã sv
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Username { get => _usename; set => _usename = value?.Trim(); }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get => _password; set => _password = value?.Trim(); }
    }
}
