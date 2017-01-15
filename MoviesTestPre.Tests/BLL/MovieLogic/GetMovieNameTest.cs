using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MoviesTestPre.BLL.Interfaces;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MovieLogic
{
    public class GetMovieNameTest : IClassFixture<MovieLogicFixure>
    {
        private readonly IMovieLogic _logic;

        public GetMovieNameTest(MovieLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task Movie_Exists_In_Collection()
        {
            var expectation = "Test 1";

            var act = await _logic.GetMovieName(1);

            act.Should().Be(expectation);
        }

        [Fact]
        public void Movie_Not_Exisst_In_Collection()
        {
            Action act = () => _logic.GetMovieName(3).Wait();

            act.ShouldThrow<InvalidOperationException>();
        }
    }
}
