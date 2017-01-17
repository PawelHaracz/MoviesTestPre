using Autofac;
using MoviesTestPre.Repository.DAL;

namespace MoviesTestPre.Infrastructures.Modules
{
    public class DbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new ApplicationDbContext()).AsSelf();
        }
    }
}