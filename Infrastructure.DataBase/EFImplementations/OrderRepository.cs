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
            return _context.Orders.Include(o => o.OrderDetails).Include(c=>c.Customer).FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders.Include(c => c.OrderDetails).Include(o=>o.Customer);
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