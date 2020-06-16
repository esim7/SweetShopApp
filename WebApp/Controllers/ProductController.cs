using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using Infrastructure.DataBase.Implementations;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly EFUnitOfWork _uow;
        public ProductController()
        {
            _uow = new EFUnitOfWork();
        }
        public ActionResult Index() => View(_uow.Products.GetAll());

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = context.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //public ActionResult Create() => View();

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Title,Price")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Products.Add(product);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = context.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Price")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(product).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = context.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = context.Products.Find(id);
        //    context.Products.Remove(product);
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