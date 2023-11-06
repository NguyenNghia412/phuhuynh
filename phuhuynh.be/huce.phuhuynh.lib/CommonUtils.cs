using huce.phuhuynh.lib.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace huce.phuhuynh.lib
{
    public class CommonUtils
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

            }
        }

        /// <summary>
        /// Lấy username hiện tại
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentUsername(IHttpContextAccessor context)
        {
            var usr = context.HttpContext?.User.FindFirst(CustomClaimTypes.UserName);
            return usr?.Value ?? "";
        }

        /// <summary>
        /// Lấy role của user hiện tại (1,2,3)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentRoles(IHttpContextAccessor context)
        {
            var usr = context.HttpContext?.User.FindFirst(CustomClaimTypes.Roles);
            return usr?.Value ?? "";
        }

        /// <summary>
        /// Lấy usertype hiện tại
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentUsertype(IHttpContextAccessor context)
        {
            var usr = context.HttpContext?.User.FindFirst(CustomClaimTypes.UserType);
            return usr?.Value ?? "";
        }

        /// <summary>
        /// Lấy tên hiển thị (họ và tên)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentDisplayName(IHttpContextAccessor context)
        {
            var usr = context.HttpContext?.User.FindFirst(CustomClaimTypes.DisplayName);
            return usr?.Value ?? "";
        }

        public static Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            return matches.Cast<Match>().ToDictionary(
                m => Uri.UnescapeDataString(m.Groups[2].Value),
                m => Uri.UnescapeDataString(m.Groups[3].Value)
            );
        }

        public static string GetFullPathFile(string folder, string fileName, string filePath)
        {
            var fullPath = Path.Combine(filePath, folder, fileName);
            return fullPath;
        }
    }
}
