using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MoviesTestPre.Common
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