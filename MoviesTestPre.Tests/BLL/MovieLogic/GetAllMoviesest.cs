using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesTestPre.BLL.Interfaces;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MovieLogic
{
    public class GetAllMoviesest : IClassFixture<MovieLogicFixure>
    {
        private readonly IMovieLogic _logic;

        public GetAllMoviesest(MovieLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task TODO()
        {
            throw new NotImplementedException();
        }
    }
}
