using System.Configuration;

namespace MoviesTestPre.Infrastructures
{
    public static class AppSettingKey
    {
        public static readonly string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        public static readonly string AppKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
        public static readonly string GraphResourceId = "https://graph.windows.net";
        public static readonly string AadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        public static readonly string Authority = $"{ConfigurationManager.AppSettings["ida:AADInstance"]}common";
    }
}