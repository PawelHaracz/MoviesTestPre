using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MoviesTestPre.BLL.Interfaces;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MovieLogic
{
    public class GetAllMoviesTest : IClassFixture<MovieLogicFixure>
    {
        private readonly IMovieLogic _logic;

        public GetAllMoviesTest(MovieLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task Simple_Test_Should_Return_All_Fake_Collection()
        {
            IDictionary<int, string> expectation = new Dictionary<int, string>
            {
                [1] = "Test 1",
                [2] = "Test 2"
            };

            var movies = await _logic.GetAllMovies();

            movies.ShouldBeEquivalentTo(expectation);
        }
    }
}
