using Domain.Model;
using Infrastructure.DataBase.Implementations;
using Infrastructure.DataBase.Interfaces;
using Ninject.Modules;

namespace WebApp.NinjectModules
{
    public class RepositoryModule : NinjectModule
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