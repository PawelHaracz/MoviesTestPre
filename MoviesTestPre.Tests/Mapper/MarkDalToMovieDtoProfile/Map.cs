using AutoMapper;
using FluentAssertions;
using MoviesTestPre.DAL;
using MoviesTestPre.DTO;
using Xunit;

namespace MoviesTestPre.Tests.Mapper.MarkDalToMovieDtoProfile
{
    public class Map : IClassFixture<MarkDalToMovieDtoProfileFixure>
    {
        private readonly IMapper _mapper;
        public Map(MarkDalToMovieDtoProfileFixure fixure)
        {
            _mapper = fixure.Mapper;
        }

        [Fact]
        public void Check_Map_Between_Models_Mark_Object_Is_Empty_Should_Return_New_Empty_MarkDTo()
        {
            var mark = new Mark();
            var expectetion = new MarkDto();

            var act = _mapper.Map<Mark, MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Check_Correct_Map_Between_Models_Mark_Object_Completely_Filled_Should_Return_Full_Mapped_MarkDto()
        {
            var mark = new Mark()
            {
                Id = 1,
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz",
                Movie = new Movie
                {
                    Id = 2,
                    Name = "Harry Potter"
                }
            };
            var expectetion = new MarkDto()
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz"
            };

            var act = _mapper.Map<Mark, MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Check_Correct_Map_Between_Models_Mark_Object_Filled_Data_Which_Take_In_Maps()
        {
            var mark = new Mark()
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz",
            };
            var expectetion = new MarkDto()
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz"
            };

            var act = _mapper.Map<Mark, MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Only_Comment_Is_Filled()
        {
            var mark = new Mark()
            {
                Comment = "test",

            };
            var expectetion = new MarkDto()
            {
                Comment = "test",
            };

            var act = _mapper.Map<Mark, MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Mark_is_filled_Only_Comment_MarkDto_Is_Null_Or_Empty_UserName()
        {
            var mark = new Mark()
            {
                Comment = "test",

            };

            var act = _mapper.Map<Mark, MarkDto>(mark);
            act.UserName.Should().BeNullOrEmpty();
        }
    }
}
