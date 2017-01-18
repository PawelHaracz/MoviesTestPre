using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
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
        public static void RetriveMoviesAndAddToDatabase(TextWriter log)
        {
            log.WriteLine("Start Download movies");

            var service = Program.MyContainer.Resolve<IMovieService>();
            var downloadMoviesTask = service.DownloadNowPlayingMovies();
            downloadMoviesTask.Wait();
            var movies = downloadMoviesTask.Result;

            log.WriteLine($"Found {movies.Count()} movies");

            var saveMoviesTask = service.SaveMoviesWhichNotExist(movies);
            saveMoviesTask.Wait();
            var addedItem = saveMoviesTask.Result;

            log.WriteLine($@"Finish, success add {addedItem} movies");

        }
    }
}
