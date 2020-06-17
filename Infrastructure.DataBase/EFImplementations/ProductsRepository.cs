using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly SweetShopDataContext _context;

        public ProductsRepository()
        {
            _context = new SweetShopDataContext();
        }

        public IList<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Create(Product item)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Product item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Product item)
        {
            throw new System.NotImplementedException();
        }

        public Product Find(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}