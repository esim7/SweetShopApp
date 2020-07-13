using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;

namespace WebApp.Controllers
{
    public class OrdersApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public OrdersApiController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/OrdersApi
        public IQueryable<Order> GetOrders()
        {
            return _uow.Orders.GetAll();
        }

        // GET: api/OrdersApi/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            var order = _uow.Orders.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/OrdersApi
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.Orders.Create(order);
            _uow.Save();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // PUT: api/OrdersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            _uow.Orders.Edit(order);
            _uow.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/OrdersApi/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            var order = _uow.Orders.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            _uow.Orders.Remove(order);
            _uow.Save();

            return Ok(order);
        }
    }
}
