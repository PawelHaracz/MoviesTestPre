using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestPre.WebJob.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<string>> DownloadNowPlayingMovies();
    }
}