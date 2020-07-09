using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly SweetShopDataContext _context;

        public CustomerRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Customer Get(int? id)
        {
            return _context.Customers.Find(id);
        }

        public IList<Customer> GetAll()
        {
            return _context.Customers.Include(o => o.Orders).ToList();
        }

        public Customer Create(Customer entity)
        {
            var customer = _context.Customers.Add(entity);
            return customer;
        }

        public Customer Edit(Customer entity)
        {
            var customer = _context.Customers.Find(entity.Id);
            if (customer != null)
            {
                customer.Name = entity.Name;
                customer.Email = entity.Email;
                customer.Phone = entity.Phone;
            }
            return customer;
        }

        public void Remove(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public DbSet GetAllEntity()
        {
            return _context.Customers;
        }

    }
}