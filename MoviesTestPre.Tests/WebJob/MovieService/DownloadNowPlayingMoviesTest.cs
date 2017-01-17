using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Flurl.Http.Testing;
using Flurl.Util;
using MoviesTestPre.SetMovies.Interfaces;
using MoviesTestPre.Tests.ExampleData;
using Xunit;

namespace MoviesTestPre.Tests.WebJob.MovieService
{
    public class DownloadNowPlayingMoviesTest : IClassFixture<MovieServiceFixure>
    {
        private readonly IMovieService _sercvice;

        public DownloadNowPlayingMoviesTest(MovieServiceFixure fixure)
        {
            _sercvice = fixure.Service;
        }

        [Fact]
        public async Task Acceptance_Test_Should_Call_To_Fake_Url_Download_Fake_Json_Should_Return_IEnumerable_With_Titles()
        {
            using (var httpTest = new HttpTest())
            {
                var fake = new FakeJsonMovie();
                var expectation = fake.ConvertedJson();
                httpTest.RespondWithJson(fake.JsonResponse());

                var movies = await _sercvice.DownloadNowPlayingMovies();

                movies.ShouldAllBeEquivalentTo(expectation);
            }
        }

        [Fact]
        public async Task Integrate_Test_Should_Download_Real_Data_And_Return_IEnumerable_With_Titles()
        {
            IEnumerable<string> movies = await _sercvice.DownloadNowPlayingMovies();
            movies.Should().NotBeNullOrEmpty();
        }

    }
}
