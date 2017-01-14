using AutoMapper;

namespace MoviesTestPre.BLL
{
    public abstract class LogicBase
    {
        protected readonly IMapper Mapper;

        protected LogicBase(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}