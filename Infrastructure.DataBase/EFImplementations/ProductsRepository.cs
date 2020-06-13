using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.Implementations
{
    public class ProductsRepository : IRepository<Product>
    {
        private SweetShopDataContext context;

        public ProductsRepository()
        {
            context = new SweetShopDataContext();
        }

        public bool Add(Product entity)
        {
            var product = context.Products.Add(entity);
            return product != null;
        }

        public bool Edit(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(params object[] id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}