using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly SweetShopDataContext _context;

        public OrderRepository()
        {
            _context = new SweetShopDataContext();
        }

        public IList<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
}