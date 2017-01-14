using AutoMapper;
using MoviesTestPre.DAL;
using MoviesTestPre.DTO;

namespace MoviesTestPre.Common.Mappers
{
    public class MarkDalToMovieDtoProfile : Profile
    {
        public MarkDalToMovieDtoProfile()
        {
            CreateMap<Mark, MarkDto>();
        }
    }
}