using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MoviesTestPre.Common.Modules;
using Owin;
    
namespace MoviesTestPre
{
    public partial class Startup
    {
        private void ConfigureDi(IAppBuilder app)
        {
           
            var builder = new ContainerBuilder();

            builder.RegisterModule(new MapperModule(InitializeMapper));
            builder.RegisterModule(new BllModule());
            builder.RegisterModule(new DbModule());
            builder.RegisterModule(new RepositoryModule());


            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}