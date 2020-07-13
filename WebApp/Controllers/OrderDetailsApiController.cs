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
    public class OrderDetailsApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public OrderDetailsApiController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/OrderDetailsApi
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            return _uow.OrderDetails.GetAll();
        }

        // GET: api/OrderDetailsApi/5
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult GetOrderDetail(int id)
        {
            var orderDetail = _uow.OrderDetails.Get(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // POST: api/OrderDetailsApi
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult PostOrderDetail(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.OrderDetails.Create(orderDetail);
            _uow.Save();

            return CreatedAtRoute("DefaultApi", new { id = orderDetail.Id }, orderDetail);
        }

        // PUT: api/OrderDetailsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            _uow.OrderDetails.Edit(orderDetail);
            _uow.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/OrderDetailsApi/5
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult DeleteOrderDetail(int id)
        {
            var orderDetail = _uow.OrderDetails.Get(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _uow.OrderDetails.Remove(orderDetail);
            _uow.Save();

            return Ok(orderDetail);
        }
    }
}
