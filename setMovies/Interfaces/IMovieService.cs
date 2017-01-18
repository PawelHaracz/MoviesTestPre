using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestPre.SetMovies.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<string>> DownloadNowPlayingMovies();
        Task<int> SaveMoviesWhichNotExist(IEnumerable<string> movies);
    }
}