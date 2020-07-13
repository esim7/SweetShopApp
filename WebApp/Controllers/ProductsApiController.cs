using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _uow.Products.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/ProductsApi
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Products.Create(product);
            _uow.Save();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT: api/ProductsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _uow.Products.Edit(product);
            _uow.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/ProductsApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = _uow.Products.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            _uow.Products.Remove(product);
            _uow.Save();

            return Ok(product);
        }
    }
}
