using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly SweetShopDataContext _context;

        public ProductsRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Product Get(int? id)
        {
            return _context.Products.Find(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product Create(Product entity)
        {
            var product = _context.Products.Add(entity);
            return product;
        }

        public Product Edit(Product entity)
        {
            var product = _context.Products.Find(entity.Id);
            if (product != null)
            {
                product.Price = entity.Price;
                product.Title = entity.Title;
            }
            return product;
        }

        public void Remove(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public DbSet GetAllEntity()
        {
            return _context.Products;
        }
    }
}