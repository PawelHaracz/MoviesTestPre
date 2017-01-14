using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using MoviesTestPre.DAL;

namespace MoviesTestPre.Common.Modules
{
    public class DbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new ApplicationDbContext()).AsSelf();
        }
    }
}