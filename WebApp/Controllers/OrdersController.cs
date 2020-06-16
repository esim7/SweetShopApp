using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using Infrastructure.DataBase.Implementations;
using Infrastructure.EntityFramework;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly EFUnitOfWork _uow;
        public OrdersController()
        {
            _uow = new EFUnitOfWork();
        }
        public ActionResult Index() => View(_uow.Orders.GetAll());

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
