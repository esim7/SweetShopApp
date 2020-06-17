using Domain.Model;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; set; }
        IRepository<Order> Orders { get; set; }
        IRepository<Customer> Customers { get; set; }
        IRepository<OrderDetail> OrderDetails { get; set; }

        void Save();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}