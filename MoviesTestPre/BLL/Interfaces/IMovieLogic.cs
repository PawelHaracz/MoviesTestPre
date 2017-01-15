using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc.Routing.Constraints;

namespace MoviesTestPre.BLL.Interfaces
{
    public interface IMovieLogic
    {
        Task<IDictionary<int, string>> GetAllMovies();
        Task<string> GetMovieName(int id);
    }
}