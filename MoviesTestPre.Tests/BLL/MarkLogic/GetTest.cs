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
    public class GetTest : IClassFixture<MarkLogicFixure>
    {
        private readonly IMarkLogic _logic;

        public GetTest(MarkLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task Id_Is_In_Collection_Should_Return_Mark()
        {
            var expectation = new MarkDto {Comment = "test 1", Id = 1, MovieId = 2, UserName = "Paweł Haracz"};

            var act = await _logic.Get(1);

            act.ShouldBeEquivalentTo(expectation);
        }

        [Fact]
        public void Id_Is_Not_In_Collection_Should_Throw_Exception()
        {
            Action act = () =>  _logic.Get(5).Wait();

            act.ShouldThrow<InvalidOperationException>();
        }
    }
}
