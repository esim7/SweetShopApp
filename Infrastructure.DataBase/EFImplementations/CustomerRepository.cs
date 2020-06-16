using System.Collections.Generic;
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
    }
}