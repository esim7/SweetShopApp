using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class OrderDetailsRepository : IRepository<OrderDetail>
    {
        private readonly SweetShopDataContext _context;

        public OrderDetailsRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public OrderDetail Get(int? id)
        {
            return _context.OrderDetails.Include(c => c.Order).Include(p=>p.Product).FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<OrderDetail> GetAll()
        {
            return _context.OrderDetails.Include(o => o.Order).Include(p => p.Product);
        }

        public OrderDetail Create(OrderDetail entity)
        {
            var orderDetail = _context.OrderDetails.Add(entity);
            return orderDetail;
        }

        public OrderDetail Edit(OrderDetail entity)
        {
            var orderDetail = _context.OrderDetails.Find(entity.Id);
            if (orderDetail != null)
            {
                orderDetail.Quantity = entity.Quantity;
            }
            return orderDetail;
        }

        public void Remove(OrderDetail entity)
        {
            _context.OrderDetails.Remove(entity);
        }

        public DbSet GetAllEntity()
        {
            return _context.OrderDetails;
        }
    }
}