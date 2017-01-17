using System;
using System.Collections.Generic;
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

        public MovieService(IConverterJson converter, IRepository<Movie> movieRepository, string endPoint, string apiKey)
        {
            _converter = converter;
            _movieRepository = movieRepository;
            _apiKey = apiKey;
            _endPoint = endPoint;
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

        public async Task SaveMoviesWhichNotExist(IEnumerable<string> movies)
        {
            foreach (var movie in movies)
            {
                var movieObj = await _movieRepository.Get(m => string.Equals(m.Name, movie, StringComparison.CurrentCultureIgnoreCase));
                if (movieObj == null)
                    await _movieRepository.Add(new Movie() { Name = movie });
            }
        }
    }
}
