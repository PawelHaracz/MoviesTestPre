using System;

namespace MoviesTestPre.SetMovies
{
    public class Setting
    {
        public string EndPoint { get; }
        public string ApiKey { get; }
        public Setting()
        {
            EndPoint = Environment.GetEnvironmentVariable("APPSETTING_EndPoint");
            ApiKey = Environment.GetEnvironmentVariable("APPSETTING_ApiKey");
        }
    }
}
