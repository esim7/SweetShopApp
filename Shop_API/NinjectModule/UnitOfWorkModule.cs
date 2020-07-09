using Infrastructure.DataBase.Implementations;
using Infrastructure.DataBase.Interfaces;

namespace Shop_API.NinjectModules
{
    public class UnitOfWorkModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}