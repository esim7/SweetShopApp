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
using WebApp.Models.Order;
using WebApp.Models.Product;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrdersController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IList<Order> orders = _uow.Orders.GetAll();
            var viewModel = _mapper.Map<IList<OrderViewModel>>(orders);

            return View(viewModel);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _uow.Orders.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var viewModel = _mapper.Map<OrderViewModel>(order);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_uow.Customers.GetAllEntity(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrderViewModel createOrderView)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(createOrderView);
                _uow.Orders.Create(order);
                _uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(_uow.Customers.GetAllEntity(), "Id", "Name", createOrderView.CustomerId);
            return View(createOrderView);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _uow.Orders.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var editOrderViewModel = _mapper.Map<EditOrderViewModel>(order);
            ViewBag.CustomerId = new SelectList(_uow.Customers.GetAllEntity(), "Id", "Name", editOrderViewModel.CustomerId);
            return View(editOrderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditOrderViewModel editOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(editOrderViewModel);
                _uow.Orders.Edit(order);
                _uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(_uow.Customers.GetAllEntity(), "Id", "Name", editOrderViewModel.CustomerId);
            return View(editOrderViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _uow.Orders.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var view = _mapper.Map<DeleteOrderViewModel>(order);
            return View(view);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = _uow.Orders.Get(id);
            _uow.Orders.Remove(order);
            _uow.Save();
            return RedirectToAction("Index");
        }
    }
}
