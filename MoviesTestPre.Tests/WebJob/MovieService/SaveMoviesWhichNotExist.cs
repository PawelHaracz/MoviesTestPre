using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
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
        public async Task Items_Not_Exists_Should_Add()
        {
            var items = new[]
            {
                "Test 3",
                "Test 4"
            };
            var expectation = 2;

           var act = await _sercvice.SaveMoviesWhichNotExist(items);

            act.Should().Be(expectation);
        }

        [Fact]
        public async Task One_Item_Exist_And_Other_Not_Exists_Should_Add_All_Expect_First()
        {
            var items = new[]
            {
                "Test 1",
                "Test 6",
                "Test 7"
            };
            var expectation = 2;

            var act = await _sercvice.SaveMoviesWhichNotExist(items);

            act.Should().Be(expectation);
        }

        [Fact]
        public async Task All_Items_Exists_In_Collection_Should_Not_Add()
        {
            var items = new[]
            {
                "Test 2",
                "Test 1"
            };
            var expectation = 0;

            var act = await _sercvice.SaveMoviesWhichNotExist(items);

            act.Should().Be(expectation);
        }

        [Fact]
        public async Task Test_Case_Sensitive_Should_Be_Not_Case_Sensitive()
        {
            var items = new[]
             {
                "TEST 2",
                "test 1"
            };
            var expectation = 0;

            var act = await _sercvice.SaveMoviesWhichNotExist(items);

            act.Should().Be(expectation);

        }
    }
}
