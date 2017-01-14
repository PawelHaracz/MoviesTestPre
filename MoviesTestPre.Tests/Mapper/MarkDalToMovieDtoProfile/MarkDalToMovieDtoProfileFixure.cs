using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MoviesTestPre.Tests.Mapper.MarkDalToMovieDtoProfile
{
    public class MarkDalToMovieDtoProfileFixure
    {
        public  IMapper Mapper { get; }
        public MarkDalToMovieDtoProfileFixure()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<Common.Mappers.MarkDalToMovieDtoProfile>();
                //cfg.CreateMap<Source, Dest>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
