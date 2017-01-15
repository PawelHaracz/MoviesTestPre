using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MoviesTestPre.WebJob.Interfaces;
using Newtonsoft.Json;

namespace MoviesTestPre.WebJob
{
    public class MovieService : IMovieService
    {
        private readonly string _apiKey;
        private readonly string _endPoint;
        private readonly IConverterJson _converter;
        public MovieService(IConverterJson converter, string endpoint, string apiKey)
        {
            _apiKey = apiKey;
            _converter = converter;
            _endPoint = endpoint;
        }

        public async Task<IEnumerable<string>> DownloadNowPlayingMovies()
        {
            string methodName = "now_playing";

            var json = await $"{_endPoint}{methodName}"
                .SetQueryParams(
                new
                {
                    region = "PL",
                    api_key = _apiKey
                })
                .GetJsonAsync();

            return _converter.Convert(json);
        }
    }
}
