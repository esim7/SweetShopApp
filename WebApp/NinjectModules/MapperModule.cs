using AutoMapper;
using Ninject.Modules;

namespace WebApp.NinjectModules
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(MapperConfig.GetMapper()).InSingletonScope();
        }
    }
}