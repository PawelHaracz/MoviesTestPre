using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MoviesTestPre.Repository.DAL;

namespace MoviesTestPre.Infrastructures.Mappers
{
    public class MovieDalToDictionaryProfile : Profile
    {
        public MovieDalToDictionaryProfile()
        {
            CreateMap<IEnumerable<Movie>, IDictionary<int, string>>()
                .ConstructUsing(x => x.ToDictionary(k => k.Id, v=> v.Name ));
        }
    }
}