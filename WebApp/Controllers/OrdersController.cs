using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Model;
using Infrastructure.DataBase.Implementations;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _uow;
        public OrdersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index() /*=> View(_uow.Orders.GetAll());*/
        {
            IList<Order> orders = _uow.Orders.GetAll();
            IList<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Order, OrderViewModel>();
            });

            var mapper = config.CreateMapper();
            var viewModel = mapper.Map<IList<OrderViewModel>>(orders);

            return View(viewModel);
        }

        //private SweetShopDataContext context = new SweetShopDataContext();

        //public ActionResult Index() => View(context.Orders.Include(o => o.Customer).ToList());

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = context.Orders.Include(o => o.Customer).FirstOrDefault(s => s.Id == id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //public ActionResult Create()
        //{
        //    ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,CustomerId,TotalPrice")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Orders.Add(order);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name", order.CustomerId);
        //    return View(order);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = context.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name", order.CustomerId);
        //    return View(order);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,CustomerId,TotalPrice")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(order).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name", order.CustomerId);
        //    return View(order);
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = context.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = context.Orders.Find(id);
        //    context.Orders.Remove(order);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
