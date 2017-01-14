using Autofac;
using MoviesTestPre.BLL;
using MoviesTestPre.BLL.Interfaces;

namespace MoviesTestPre.Common.Modules
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MarkLogic>().As<IMarkLogic>();
        }
    }
}