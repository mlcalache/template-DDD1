using System.Configuration;

namespace DDD_Template1.Infra.CrossCutting.Helpers
{
    public static class ConfigurationManagerHelper
    {
        public static string AccessTokenExpirationMinutes => ConfigurationManager.AppSettings["AccessTokenExpirationMinutes"];
        public static string ApiAuthenticationUrl => ConfigurationManager.AppSettings["ApiAuthenticationUrl"];
        public static string ApiBaseUrl => ConfigurationManager.AppSettings["ApiBaseUrl"];
        public static string CookieExpirationInMinutes => ConfigurationManager.AppSettings["CookieExpirationInMinutes"];
        public static string UrlJsonAirport => ConfigurationManager.AppSettings["UrlJsonAirport"];
    }
}