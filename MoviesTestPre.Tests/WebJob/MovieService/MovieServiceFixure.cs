using MoviesTestPre.WebJob.Converters;
using MoviesTestPre.WebJob.Interfaces;

namespace MoviesTestPre.Tests.WebJob.MovieService
{
    public class MovieServiceFixure
    {
        public readonly IMovieService Service;

        public MovieServiceFixure()
        {
            var converter = new MovieNowPlayingConverter();
            Service = new MoviesTestPre.WebJob.MovieService(converter, "https://api.themoviedb.org/3/movie/", "05e64ca9b0e040334b739e85999d7c48");
        }
    }
}
