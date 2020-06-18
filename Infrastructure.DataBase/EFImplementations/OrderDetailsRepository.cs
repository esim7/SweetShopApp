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
            return _context.OrderDetails.Find(id);
        }

        public IList<OrderDetail> GetAll()
        {
            return _context.OrderDetails.ToList();
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
                orderDetail.ProductId = entity.ProductId;
                orderDetail.Quantity = entity.Quantity;
                orderDetail.OrderId = entity.OrderId;
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