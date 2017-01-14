using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MoviesTestPre.DAL;
using MoviesTestPre.Tests.Mapper.MarkDalToMovieDtoProfile;
using Xunit;

namespace MoviesTestPre.Tests.Mapper.MovieDalToDictionaryProfile
{
    public class Map : IClassFixture<MovieDalToDictionaryProfileFixure>
    {
        private readonly IMapper _mapper;
        public Map(MovieDalToDictionaryProfileFixure fixure)
        {
            _mapper = fixure.Mapper;
        }

        [Fact]
        public void Empty_collection_Should_Return_Empty_Dictionary()
        {
            IEnumerable<Movie> movies = new List<Movie>();
            IDictionary<int,string> expectetion = new Dictionary<int, string>();

            var act = _mapper.Map<IDictionary<int, string>>(movies);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Collection_Has_One_Element_Should_Return_dictionary_With_One_KeyValue()
        {
            IEnumerable<Movie> movies = new List<Movie>()
            {
                new Movie
                {
                    Id = 2,
                    Name = "Harry Potter"
                }
            };
            IDictionary<int, string> expectetion = new Dictionary<int, string>
            {
                [2] = "Harry Potter"
            };

            var act = _mapper.Map<IDictionary<int, string>>(movies);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Many_Item_Correct_Map_To_Dictionary()
        {
            IEnumerable<Movie> movies = new List<Movie>()
            {
                new Movie
                {
                    Id = 2,
                    Name = "Harry Potter"
                },
                new Movie
                {
                    Id = 3,
                    Name = "Harry Potter 1"
                },
                 new Movie
                {
                    Id = 4,
                    Name = "Harry Potter 2"
                }
            };
            IDictionary<int, string> expectetion = new Dictionary<int, string>
            {
                [2] = "Harry Potter",
                [3] = "Harry Potter 1",
                [4] = "Harry Potter 2"
            };

            var act = _mapper.Map<IDictionary<int, string>>(movies);

            act.ShouldBeEquivalentTo(expectetion);
        }

        [Fact]
        public void Collection_Has_Duplicate_Should_Throw_Exception()
        {
            IEnumerable<Movie> movies = new List<Movie>()
            {
                new Movie
                {
                    Id = 2,
                    Name = "Harry Potter"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Harry Potter"
                }
            };

            Action act = () => _mapper.Map<IDictionary<int, string>>(movies);

            act.ShouldThrow<ArgumentException>();
        }
    }
}
