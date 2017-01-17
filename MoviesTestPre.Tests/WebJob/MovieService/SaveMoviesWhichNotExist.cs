using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesTestPre.SetMovies.Interfaces;
using Xunit;

namespace MoviesTestPre.Tests.WebJob.MovieService
{
    public class SaveMoviesWhichNotExist : IClassFixture<MovieServiceFixure>
    {
        private readonly IMovieService _sercvice;

        public SaveMoviesWhichNotExist(MovieServiceFixure fixure)
        {
            _sercvice = fixure.Service;
        }

        [Fact]
        public async Task TODO()
        {
            throw new NotImplementedException();
        }
    }
}
