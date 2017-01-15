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
        public async Task TODo()
        {
            var mark = new MarkDto
            {
                Comment = "Test",
                MovieId = 2,
                UserName = "Pawel Haracz"
            };

            var act = await _logic.Create(mark);

            act.Should().Be(4);
        }
    }
}
