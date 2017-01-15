using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesTestPre.Repository;
using Xunit;
using FluentAssertions;

namespace MoviesTestPre.Tests.Repository.DocumentDbRepository
{
    public class GetItemsTest : IClassFixture<DocumentDbRepositoryFixure>
    {
        private readonly IDocumentDbRepository<ExampleModel> _fixure;

        public GetItemsTest(DocumentDbRepositoryFixure fixure)
        {
            _fixure = fixure.Fixure;
        }

        [Fact]
        public async Task Get_All_Items()
        {
            var expectation = new List<ExampleModel>()
            {
                new ExampleModel() {Name = "A", Number = 25},
                new ExampleModel() {Name = "@#d", Number = -8587}
            };

            var items = await _fixure.GetItemsAsync(p => true);

            items.ShouldBeEquivalentTo(expectation);

        }

        [Fact]
        public async Task Get_Where_Number_Eq_25()
        {
            var expectation = new List<ExampleModel>()
            {
                new ExampleModel {Name = "A", Number = 25}

            };

            var items = await _fixure.GetItemsAsync(p => p.Number == 25);

            items.ShouldBeEquivalentTo(expectation);
        }

        [Fact]
        public async Task Set_Null_In_Where_Should_Throw_Exception()
        {

            Func<Task> action = async () => await _fixure.GetItemsAsync(null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
