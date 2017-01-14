using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MoviesTestPre.Tests.Mapper.MovieDalToDictionaryProfile
{
    public class MovieDalToDictionaryProfileFixure
    {
        public readonly IMapper Mapper;

        public MovieDalToDictionaryProfileFixure()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<Infrastructures.Mappers.MovieDalToDictionaryProfile>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
