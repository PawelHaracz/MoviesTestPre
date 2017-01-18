using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories.Interfaces;
using MoviesTestPre.SetMovies.Interfaces;

namespace MoviesTestPre.SetMovies
{
    public class MovieService : IMovieService
    {
        private readonly string _apiKey;
        private readonly string _endPoint;
        private readonly IConverterJson _converter;
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IConverterJson converter, IRepository<Movie> movieRepository, MovieWebSetting setting)
        {
            _converter = converter;
            _movieRepository = movieRepository;
            _apiKey = setting.ApiKey;
            _endPoint = setting.EndPoint;
        }

        public async Task<IEnumerable<string>> DownloadNowPlayingMovies()
        {
            string methodName = "movie/now_playing";

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

        public async Task<int> SaveMoviesWhichNotExist(IEnumerable<string> movies)
        {
            var  i = 0;
            foreach (var movie in movies)
            {
                var movieObj = await _movieRepository.Get(m => m.Name.ToLower() == movie.ToLower());
                if (movieObj.Any()) continue;

                await _movieRepository.Add(new Movie { Name = movie });
                i++;
            }
            return i;
        }
    }
}
