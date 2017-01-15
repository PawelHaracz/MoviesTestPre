using System.Threading.Tasks;
using FluentAssertions;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.DTO;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MarkLogic
{
    public class CreateTest : IClassFixture<MarkLogicFixure>
    {
        private readonly IMarkLogic _logic;

        public CreateTest(MarkLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task Mark_Has_Filled_Comment_MovieId_UserName_Should_Corect_Add_To_Collection()
        {
            var mark = new MarkDto
            {
                Comment = "Test",
                MovieId = 2,
                UserName = "Pawel Haracz"
            };

            var act = await _logic.Create(mark);

            act.Should().BeGreaterThan(3);
        }

        [Fact]
        public async Task Empty_Mark_Should_Be_Ok()
        {
            var mark = new MarkDto();
            
            var act = await _logic.Create(mark);

            act.Should().BeGreaterThan(3);
        }
    }
}
