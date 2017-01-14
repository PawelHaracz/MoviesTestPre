using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MoviesTestPre.Tests.Mapper.MarkDalToMovieDtoProfile;
using Xunit;

namespace MoviesTestPre.Tests.Mapper.MovieDalToDictionaryProfile
{
    public class Map : IClassFixture<MarkDalToMovieDtoProfileFixure>
    {
        private readonly IMapper _mapper;
        public Map(MarkDalToMovieDtoProfileFixure fixure)
        {
            _mapper = fixure.Mapper;
        }

        [Fact]
        public void TODO()
        {
            throw new NotImplementedException();
        }
    }
}
