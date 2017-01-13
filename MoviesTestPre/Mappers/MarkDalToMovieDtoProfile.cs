using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MoviesTestPre.DAL;
using MoviesTestPre.DTO;

namespace MoviesTestPre.Mappers
{
    public class MarkDalToMovieDtoProfile : Profile
    {
        public MarkDalToMovieDtoProfile()
        {
            CreateMap<Mark, MarkDto>();
        }
    }
}