using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories;
using MoviesTestPre.Repository.Repositories.Interfaces;
using MoviesTestPre.SetMovies;
using MoviesTestPre.SetMovies.Converters;
using MoviesTestPre.SetMovies.Interfaces;

namespace MoviesTestPre.SetMovies
{
    public class Functions
    {
        // This function will be triggered based on the schedule you have set for this WebJob
        // This function will enqueue a message on an Azure Queue called queue
        [NoAutomaticTrigger]
        public static void ManualTrigger(TextWriter log, int value)
        {
            log.WriteLine("Start Download movies");

            IConverterJson converter = new MovieNowPlayingConverter();
            Setting setting = new Setting();
            IRepository<Movie> movieRepository = new MovieRepository(new ApplicationDbContext());
            IMovieService service = new MovieService(converter, movieRepository, setting.EndPoint, setting.ApiKey);

            service.DownloadNowPlayingMovies().Wait();
            var movies = service.DownloadNowPlayingMovies().Result;

            log.WriteLine($"Found {movies.Count()} movies");

            service.SaveMoviesWhichNotExist(movies).Wait();

            log.WriteLine("Finish");

        }
    }
}
