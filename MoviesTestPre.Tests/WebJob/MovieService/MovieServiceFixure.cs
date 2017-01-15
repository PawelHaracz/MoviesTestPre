using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesTestPre.WebJob;
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
            Service = new MoviesTestPre.WebJob.MovieService(converter, "https://api.themoviedb.org/3/movie/", "");
        }
    }
}
