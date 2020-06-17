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

        public CustomerRepository()
        {
            _context = new SweetShopDataContext();
        }

        public IList<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Create(Customer item)
        {
            _context.Customers.Add(item);
        }

        public void Edit(Customer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Remove(Customer item)
        {
            _context.Customers.Remove(item);
        }

        public Customer Find(int? id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}