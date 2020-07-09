using Infrastructure.EntityFramework;

namespace Shop_API.NinjectModule
{
    public class DataContextModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<SweetShopDataContext>().ToSelf().InSingletonScope();
        }
    }
}