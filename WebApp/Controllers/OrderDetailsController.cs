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
    public class OrderDetailsController : Controller
    {

        private readonly IUnitOfWork _uow;
        public OrderDetailsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index() /*=> View(_uow.OrderDetails.GetAll());*/
        {
            
            IList<OrderDetail> orderDetails = _uow.OrderDetails.GetAll();
            IList<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();

            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<OrderDetail, OrderDetailsViewModel>();
            });

            var mapper = config.CreateMapper();
            var viewModel = mapper.Map<IList<OrderDetailsViewModel>>(orderDetails);

            return View(viewModel);
            
        }
        //private SweetShopDataContext context = new SweetShopDataContext();

        //public ActionResult Index() => View(context.OrderDetails.Include(o => o.Order).Include(o => o.Product).ToList());

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = context.OrderDetails.Include(o => o.Product).Include(x => x.Order).FirstOrDefault(s => s.Id == id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orderDetail);
        //}

        //public ActionResult Create()
        //{
        //    ViewBag.OrderId = new SelectList(context.Orders, "Id", "Id");
        //    ViewBag.ProductId = new SelectList(context.Products, "Id", "Title");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ProductId,Quantity,OrderId")] OrderDetail orderDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.OrderDetails.Add(orderDetail);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.OrderId = new SelectList(context.Orders, "Id", "Id", orderDetail.OrderId);
        //    ViewBag.ProductId = new SelectList(context.Products, "Id", "Title", orderDetail.ProductId);
        //    return View(orderDetail);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = context.OrderDetails.Find(id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.OrderId = new SelectList(context.Orders, "Id", "Id", orderDetail.OrderId);
        //    ViewBag.ProductId = new SelectList(context.Products, "Id", "Title", orderDetail.ProductId);
        //    return View(orderDetail);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ProductId,Quantity,OrderId")] OrderDetail orderDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(orderDetail).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.OrderId = new SelectList(context.Orders, "Id", "Id", orderDetail.OrderId);
        //    ViewBag.ProductId = new SelectList(context.Products, "Id", "Title", orderDetail.ProductId);
        //    return View(orderDetail);
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = context.OrderDetails.Find(id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orderDetail);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    OrderDetail orderDetail = context.OrderDetails.Find(id);
        //    context.OrderDetails.Remove(orderDetail);
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
