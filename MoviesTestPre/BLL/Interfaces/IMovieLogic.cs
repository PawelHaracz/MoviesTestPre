using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestPre.BLL.Interfaces
{
    public interface IMovieLogic
    {
        Task<Dictionary<int, string>> GetAllMovies();
    }
}