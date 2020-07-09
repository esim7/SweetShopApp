using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Model;
using Infrastructure.DataBase.Implementations;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace WebApp.Controllers
{
    public class ProductsApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public ProductsApiController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductsApi
        public IEnumerable<Product> Get()
        {
            return _uow.Products.GetAll();
        }

        // GET: api/ProductsApi/5
        public Product Get(int id)
        {
            return _uow.Products.Get(id);
        }

        // POST: api/ProductsApi
        public Product Post([FromBody] Product product)
        {
            var savedProduct = _uow.Products.Create(product);
            _uow.Save();
            return savedProduct;
        }

        // PUT: api/ProductsApi/5
        public Product Put(/*int id, [FromBody]*/Product product)
        {
            var changedProduct = _uow.Products.Edit(product);
            _uow.Save();
            return changedProduct;
        }

        // DELETE: api/ProductsApi/5
        public void Delete(Product product)
        {
            _uow.Products.Remove(product);
            _uow.Save();
        }
    }
}
