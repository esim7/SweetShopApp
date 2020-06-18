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
using WebApp.Models.OrderDetail;

namespace WebApp.Controllers
{
    public class OrderDetailsController : Controller
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public OrderDetailsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {

            IList<OrderDetail> orderDetails = _uow.OrderDetails.GetAll();
            var viewModel = _mapper.Map<IList<OrderDetailsViewModel>>(orderDetails);
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orderDetail = _uow.OrderDetails.Get(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            var viewModel = _mapper.Map<OrderDetailsViewModel>(orderDetail);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(_uow.Orders.GetAllEntity(), "Id", "Id");
            ViewBag.ProductId = new SelectList(_uow.Products.GetAllEntity(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrderDetailsViewModel createOrderDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetail = _mapper.Map<OrderDetail>(createOrderDetailsViewModel);
                _uow.OrderDetails.Create(orderDetail);
                _uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(_uow.Orders.GetAllEntity(), "Id", "Id", createOrderDetailsViewModel.OrderId);
            ViewBag.ProductId = new SelectList(_uow.Products.GetAllEntity(), "Id", "Title", createOrderDetailsViewModel.ProductId);
            return View(createOrderDetailsViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetail = _uow.OrderDetails.Get(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            var view = _mapper.Map<EditOrderDetailsViewModel>(orderDetail);
            ViewBag.OrderId = new SelectList(_uow.Orders.GetAllEntity(), "Id", "Id", view.OrderId);
            ViewBag.ProductId = new SelectList(_uow.Products.GetAllEntity(), "Id", "Title", view.ProductId);
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditOrderDetailsViewModel editOrderDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetail = _mapper.Map<OrderDetail>(editOrderDetailsViewModel);
                _uow.OrderDetails.Edit(orderDetail);
                _uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(_uow.Orders.GetAllEntity(), "Id", "Id", editOrderDetailsViewModel.OrderId);
            ViewBag.ProductId = new SelectList(_uow.Products.GetAllEntity(), "Id", "Title", editOrderDetailsViewModel.ProductId);
            return View(editOrderDetailsViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetail = _uow.OrderDetails.Get(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }

            var view = _mapper.Map<DeleteOrderDetailsViewModel>(orderDetail);
            return View(view);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var orderDetail = _uow.OrderDetails.Get(id);
            _uow.OrderDetails.Remove(orderDetail);
            _uow.Save();
            return RedirectToAction("Index");
        }
    }
}
