using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using MoviesTestPre.DTO;
using MoviesTestPre.Repository.DAL;
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

            var act = _mapper.Map<MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Check_Correct_Map_Between_Models_Mark_Object_Completely_Filled_Should_Return_Full_Mapped_MarkDto()
        {
            var mark = new Mark
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
            var expectetion = new MarkDto
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz",
                Id = 1,
            };

            var act = _mapper.Map<MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Check_Correct_Map_Between_Models_Mark_Object_Filled_Data_Which_Take_In_Maps()
        {
            var mark = new Mark
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz",
            };
            var expectetion = new MarkDto
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz"
            };

            var act = _mapper.Map<MarkDto>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Only_Comment_Is_Filled()
        {
            var mark = new Mark
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

            var act = _mapper.Map<MarkDto>(mark);
            act.UserName.Should().BeNullOrEmpty();
        }

        [Fact]
        public void IEnumerable_With_Empty_Marks_Should_Convert_To_IEnumerable_Empty_MarkDto()
        {
            IEnumerable<Mark> marks = new List<Mark>() { new Mark() };
            IEnumerable<MarkDto> expectetion = new List<MarkDto>() { new MarkDto() };

            var act = _mapper.Map<IEnumerable<MarkDto>>(marks);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void IEnumerable_with_Completly_Filled_Mark_Should_Return_IEnumberable_With_Completly_Filled_Mark()
        {
            IEnumerable<Mark> marks = new List<Mark>{
                new Mark
                {
                    Comment = "test2",
                    MovieId = 3,
                    UserName = "Bla bla",
                    Id = 3
                },
                new Mark
                {
                    Id = 4,
                    Comment = "23TR",
                    MovieId = 5,
                    UserName = "Haracz Paweł"
                }
            };
            IEnumerable<MarkDto> expectetion = new List<MarkDto> {
                new MarkDto
                {
                        Comment = "test2",
                        MovieId = 3,
                        UserName = "Bla bla",
                        Id = 3
                },
                new MarkDto
                {
                    Comment = "23TR",
                    MovieId = 5,
                    UserName = "Haracz Paweł",
                    Id = 4,
                }
            };

            var act = _mapper.Map<IEnumerable<MarkDto>>(marks);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void MarkDto_To_Mark()
        {
            var mark = new MarkDto
            {
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz",
                Id = 1,
            };

            var expectetion = new Mark
            {
                Id = 1,
                Comment = "test",
                MovieId = 2,
                UserName = "Paweł Haracz",
                Movie = null
            };

            var act = _mapper.Map<Mark>(mark);

            act.ShouldBeEquivalentTo(expectetion);
        }
    }
}
