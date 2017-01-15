using Owin;

namespace MoviesTestPre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureDi(app);
        }
    }
}
