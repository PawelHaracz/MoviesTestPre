using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.DAL;
using MoviesTestPre.DTO;
using Xunit;

namespace MoviesTestPre.Tests.BLL.MarkLogic
{
    public class GetAllTest : IClassFixture<MarkLogicFixure>
    {
        private readonly IMarkLogic _logic;

        public GetAllTest(MarkLogicFixure fixure)
        {
            _logic = fixure.Logic;
        }

        [Fact]
        public async Task User_Has_Name_Pawel_And_He_Is_Admin_Should_Return_All_Collection()
        {
            IEnumerable<MarkDto> marks = new List<MarkDto>
            {
                new MarkDto {Comment = "test 1", MovieId = 2, UserName = "Paweł Haracz"},
                new MarkDto {Comment = "test 2", MovieId = 2, UserName = "Jakub Testowy"},
                new MarkDto {Comment = "test 3", MovieId = 3, UserName = "Paweł Haracz"}
            };

            var act = await _logic.GetAll("Pawel", true);

            act.ShouldBeEquivalentTo(marks);
        }

        [Fact]
        public async Task User_Has_Name_Pawel_Haracz_He_Is_Not_Admin_Should_Return_Own_Records()
        {
            IEnumerable<MarkDto> marks = new List<MarkDto>
            {
                new MarkDto {Comment = "test 1", MovieId = 2, UserName = "Paweł Haracz"},
                new MarkDto {Comment = "test 3", MovieId = 3, UserName = "Paweł Haracz"}
            };

            var act = await _logic.GetAll("Paweł Haracz", false);

            act.ShouldBeEquivalentTo(marks);
        }

    }
}
