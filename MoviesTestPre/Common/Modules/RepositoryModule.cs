using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using MoviesTestPre.DAL;
using MoviesTestPre.Repositories;
using MoviesTestPre.Repositories.Interfaces;

namespace MoviesTestPre.Common.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MarkRepository>().As<IRepository<Mark>>();
        }
    }
}