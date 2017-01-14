using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MoviesTestPre.DAL;

namespace MoviesTestPre.Infrastructures.Mappers
{
    public class MovieDalToDictionaryProfile : Profile
    {
        public MovieDalToDictionaryProfile()
        {
            CreateMap<IEnumerable<Movie>, IDictionary<int, string>>();
        }
    }
}