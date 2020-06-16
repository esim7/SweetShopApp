using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly SweetShopDataContext _context;

        public IRepository<Product> Products { get; set; }
        public IRepository<Order> Orders { get; set; }
        public IRepository<Customer> Customers { get; set; }
        public IRepository<OrderDetail> OrderDetails { get; set; }

        public EFUnitOfWork()
        {
            Products = new ProductsRepository();
            Orders = new OrderRepository();
            Customers = new CustomerRepository();
            OrderDetails = new OrderDetailsRepository();
            _context = new SweetShopDataContext();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }
    }
}