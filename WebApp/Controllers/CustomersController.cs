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
using WebApp.Models.Customer;
using WebApp.Models.Product;
using WebGrease.Css.Extensions;

namespace WebApp.Controllers
{
    public class CustomersController : Controller
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CustomersController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IList<Customer> customers = _uow.Customers.GetAll();
            var viewModel = _mapper.Map<IList<CustomerViewModel>>(customers);
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _uow.Customers.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = _mapper.Map<CustomerViewModel>(customer);
            return View(viewModel);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerViewModel createCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(createCustomerViewModel);
                _uow.Customers.Create(customer);
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _uow.Customers.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = _mapper.Map<EditCustomerViewModel>(customer);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCustomerViewModel editCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(editCustomerViewModel);
                _uow.Customers.Edit(customer);
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(editCustomerViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _uow.Customers.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var deleteCustomerViewModel = _mapper.Map<DeleteCustomerViewModel>(customer);
            return View(deleteCustomerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _uow.Customers.Get(id);
            _uow.Customers.Remove(customer);
            _uow.Save();
            return RedirectToAction("Index");
        }
    }
}
    
