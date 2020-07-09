using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<Customer> Get()
        {
            var customers = _uow.Customers.GetAll();
            return customers;
        }

        // GET: api/CustomersApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CustomersApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomersApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomersApi/5
        public void Delete(int id)
        {
        }
    }
}
