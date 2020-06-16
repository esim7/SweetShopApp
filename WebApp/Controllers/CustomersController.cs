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
    public class CustomersController : Controller
    {

        private readonly EFUnitOfWork _uow;
        public CustomersController()
        {
            _uow = new EFUnitOfWork();
        }
        public ActionResult Index() => View(_uow.Customers.GetAll());
        //    private SweetShopDataContext context = new SweetShopDataContext();

        //    public ActionResult Index() => View(context.Customers.ToList());

        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Customer customer = context.Customers.Find(id);
        //        if (customer == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(customer);
        //    }

        //    public ActionResult Create() => View();

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "Id,Name,Email,Phone")] Customer customer)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            context.Customers.Add(customer);
        //            context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(customer);
        //    }

        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Customer customer = context.Customers.Find(id);
        //        if (customer == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(customer);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone")] Customer customer)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            context.Entry(customer).State = EntityState.Modified;
        //            context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(customer);
        //    }

        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Customer customer = context.Customers.Find(id);
        //        if (customer == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(customer);
        //    }

        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Customer customer = context.Customers.Find(id);
        //        context.Customers.Remove(customer);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
    
