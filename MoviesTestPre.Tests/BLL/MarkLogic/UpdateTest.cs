using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.DTO;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MarkLogic
{
    public class UpdateTest : IClassFixture<MarkLogicFixure>
    {
        private readonly IMarkLogic _logic;
        public UpdateTest(MarkLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task Change_Properties_Values()
        {
            var mark = new MarkDto
            {
                Id = 1,
                Comment = "Test Update",
                MovieId = 1,
                UserName = "Pawel Haracz 1"
            };

            var add = await _logic.Update(mark);
            var act = await _logic.Get(add);

            act.ShouldBeEquivalentTo(mark);
        }
    }
}
