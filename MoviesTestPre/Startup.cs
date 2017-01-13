using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Owin;
using MoviesTestPre.Mappers;
using Owin;

namespace MoviesTestPre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //todo add autofac i Imapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MarkDalToMovieDtoProfile>();
            });
            var mapper = config.CreateMapper();
        }
    }
}
