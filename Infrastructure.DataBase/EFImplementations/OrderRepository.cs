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

        public void Create(Order item)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Order item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Order item)
        {
            throw new System.NotImplementedException();
        }

        public Order Find(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}