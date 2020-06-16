using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class OrderDetailsRepository : IRepository<OrderDetail>
    {
        private readonly SweetShopDataContext _context;

        public OrderDetailsRepository()
        {
            _context = new SweetShopDataContext();
        }

        public IList<OrderDetail> GetAll()
        {
            return _context.OrderDetails.ToList();
        }
    }
}