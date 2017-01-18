using System;

namespace MoviesTestPre.SetMovies
{
    public class MovieWebSetting
    {
        public string EndPoint { get; private set; }
        public string ApiKey { get; private set; }

        public MovieWebSetting(string endPoint, string apiKey)
        {
            EndPoint = endPoint;
            ApiKey = apiKey;

        }
    }
}