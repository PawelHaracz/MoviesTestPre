using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Owin;
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
