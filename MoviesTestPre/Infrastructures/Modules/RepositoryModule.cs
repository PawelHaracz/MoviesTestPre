using Autofac;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories;
using MoviesTestPre.Repository.Repositories.Interfaces;

namespace MoviesTestPre.Infrastructures.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MarkRepository>().As<IRepository<Mark>>();
            builder.RegisterType<MovieRepository>().As<IRepository<Movie>>();

        }
    }
}