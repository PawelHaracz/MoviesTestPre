using System;
using Autofac;
using AutoMapper;

namespace MoviesTestPre.Common.Modules
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
            builder.Register<IMapper>((ctx,param) => _mapperFunc()).SingleInstance();
        }
    }
}