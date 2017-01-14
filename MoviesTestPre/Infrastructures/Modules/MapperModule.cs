using System;
using Autofac;
using AutoMapper;

namespace MoviesTestPre.Infrastructures.Modules
{
    public class MapperModule : Module
    {
        private readonly Func<IMapper> _mapperFunc;

        public MapperModule(Func<IMapper> mapperFunc)
        {
            _mapperFunc = mapperFunc;
        }
       
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((ctx,param) => _mapperFunc()).SingleInstance();
        }
    }
}