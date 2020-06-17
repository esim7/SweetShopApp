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
using WebGrease.Css.Extensions;

namespace WebApp.Controllers
{
    public class CustomersController : Controller
    {

        private readonly IUnitOfWork _uow;
        public CustomersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private CustomerViewModel CustomerModelMapper(Customer customer, CustomerViewModel viewModel)
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Customer, CustomerViewModel>();
            });

            var mapper = config.CreateMapper();
            return viewModel = mapper.Map<CustomerViewModel>(customer);
        }

        public ActionResult Index()
        {
            IList<Customer> customers = _uow.Customers.GetAll();
            IList<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();

            foreach (var element in customers)
            {
                customerViewModels.Add(CustomerModelMapper(element, new CustomerViewModel()));
            }
            return View(customerViewModels);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _uow.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(CustomerModelMapper(customer, new CustomerViewModel()));
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
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
            Customer customer = _uow.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(CustomerModelMapper(customer, new CustomerViewModel()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _uow.Customers.Edit(customer);
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(CustomerModelMapper(customer, new CustomerViewModel()));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _uow.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(CustomerModelMapper(customer, new CustomerViewModel()));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _uow.Customers.Find(id);
            _uow.Customers.Remove(customer);
            _uow.Save();
            return RedirectToAction("Index");
        }
    }
}
    
