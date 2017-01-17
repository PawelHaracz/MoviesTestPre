using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories.Interfaces;

namespace MoviesTestPre.BLL
{
    public class MovieLogic : LogicBase, IMovieLogic
    {
        private readonly IRepository<Movie> _repository;

        public MovieLogic(IMapper mapper,IRepository<Movie> repository)
            :base(mapper)
        {
            _repository = repository;
        }

        public async Task<IDictionary<int, string>> GetAllMovies()
        {
            var movies = await _repository.Get(_ => true);

            return Mapper.Map<IDictionary<int, string>>(movies);
        }

        public async Task<string> GetMovieName(int id)
        {
            var movie = await _repository.Find(id);

            return movie.Name;
        }
    }
}