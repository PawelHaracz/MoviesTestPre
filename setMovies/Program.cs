using System;
using Autofac;
using Microsoft.Azure.WebJobs;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories;
using MoviesTestPre.Repository.Repositories.Interfaces;
using MoviesTestPre.SetMovies.Converters;
using MoviesTestPre.SetMovies.Interfaces;

namespace MoviesTestPre.SetMovies
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        public static IContainer MyContainer { get; private set; }
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage

        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MovieNowPlayingConverter>().As<IConverterJson>();
            builder.Register(ctx =>
                new MovieWebSetting(
                    Environment.GetEnvironmentVariable("APPSETTING_EndPoint"),
                    Environment.GetEnvironmentVariable("APPSETTING_ApiKey"))
                )
            .AsSelf();
            builder.RegisterType<MovieRepository>().As<IRepository<Movie>>();
            builder.RegisterType<MovieService>().As<IMovieService>();
            builder.Register(ctx => new ApplicationDbContext()).AsSelf();

            MyContainer = builder.Build();
            var host = new JobHost();
            // The following code will invoke a function called ManualTrigger and 
            // pass in data (value in this case) to the function
            host.Call(typeof(Functions).GetMethod("RetriveMoviesAndAddToDatabase"));
        }
    }
}
