using IdentityServer4.Models;
using System.Collections;
using System.Collections.Generic;

namespace huce.phuhuynh.identityserver
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes { get; set; }
        public static IEnumerable<Client> Clients { get; set; }

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> { new IdentityResources.OpenId(), new IdentityResources.Profile() };

    }

    public static class CustomResponseKey
    {
        public const string CODE = "code";
        public const string MESSAGE = "message";
        public const string EXCEPTION = "exception";
        public const string IS_FIRST_TIME = "is_first_time";
        public const string IS_TEMP_PASSWORD = "is_temp_password";
        public const string IS_EKYC = "is_ekyc";
        public const string IS_HAVE_PIN = "is_have_pin";
        public const string IS_VERIFIED_EMAIL = "is_verified_email";
        public const string IS_VERIFIED_FACE = "is_verified_face";
        public const string IS_TEMP_PIN = "is_temp_pin";
    }

    public static class GrantTypes
    {
        public const string CAN_BO = "canbo";
    }

    /// <summary>
    /// Key lấy trường tự định nghĩa khi gọi api đăng nhập
    /// </summary>
    public static class RawRequestKey
    {
        public const string User = "username";
        public const string PASSWORD = "password";
    }
}
