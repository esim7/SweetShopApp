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
using Infrastructure.DataBase.Interfaces;

namespace WebApp.Controllers
{
    public class CustomersApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public CustomersApiController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CustomersApi
        public IQueryable<Customer> GetCustomers()
        {
            return _uow.Customers.GetAll();
        }

        // GET: api/CustomersApi/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _uow.Customers.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/CustomersApi
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Customers.Create(customer);
            _uow.Save();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // PUT: api/CustomersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _uow.Customers.Edit(customer);
            _uow.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/CustomersApi/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _uow.Customers.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            _uow.Customers.Remove(customer);
            _uow.Save();

            return Ok(customer);
        }
    }
}
