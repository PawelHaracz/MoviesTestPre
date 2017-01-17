using AutoMapper;
using MoviesTestPre.DTO;
using MoviesTestPre.Repository.DAL;

namespace MoviesTestPre.Infrastructures.Mappers
{
    public class MarkDalToMovieDtoProfile : Profile
    {
        public MarkDalToMovieDtoProfile()
        {
            CreateMap<Mark, MarkDto>();
            CreateMap<MarkDto, Mark>();
        }
    }
}