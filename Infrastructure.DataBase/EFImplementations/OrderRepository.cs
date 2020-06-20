using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly SweetShopDataContext _context;

        public OrderRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Order Get(int? id)
        {
            return _context.Orders.Find(id);
        }

        public IList<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Customer).ToList();
        }

        public Order Create(Order entity)
        {
            var order = _context.Orders.Add(entity);
            return order;
        }

        public Order Edit(Order entity)
        {
            var order = _context.Orders.Find(entity.Id);
            if (order != null)
            {
                order.CustomerId = entity.CustomerId;
                order.TotalPrice = entity.TotalPrice;
            }
            return order;
        }

        public void Remove(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public DbSet GetAllEntity()
        {
            return _context.Orders;
        }
    }
}