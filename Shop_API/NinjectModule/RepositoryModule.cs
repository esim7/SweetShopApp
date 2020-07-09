using Domain.Model;
using Infrastructure.DataBase.Implementations;
using Infrastructure.DataBase.Interfaces;

namespace Shop_API.NinjectModules
{
    public class RepositoryModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Product>>().To<ProductsRepository>();
            Bind<IRepository<OrderDetail>>().To<OrderDetailsRepository>();
            Bind<IRepository<Order>>().To<OrderRepository>();
            Bind<IRepository<Customer>>().To<CustomerRepository>();
        }
    }
}