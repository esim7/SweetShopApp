using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Model;

using Infrastructure.DataBase.Interfaces;
using WebApp.Models;
using WebApp.Models.Product;


namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IList<Product> products = _uow.Products.GetAll();
            var viewModel = _mapper.Map<IList<ProductViewModel>>(products);

            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var viewModel = _mapper.Map<ProductViewModel>(product);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel createProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(createProductViewModel);
                _uow.Products.Create(product);
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _uow.Products.Get((int)id);

            if (product == null)
                return HttpNotFound("Product not found!");

            var editProductViewModel = _mapper.Map<EditProductViewModel>(product);

            return View(editProductViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(editProductViewModel);
                product = _uow.Products.Edit(product);
                _uow.Save();

                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _uow.Products.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var deleteProductViewModel = _mapper.Map<DeleteProductViewModel>(product);
            return View(deleteProductViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _uow.Products.Get(id);
            _uow.Products.Remove(product);
            _uow.Save();
            return RedirectToAction("Index");
        }

        //public ActionResult Buy(int? id)
        //{
        //    return View(editProductViewModel);
        //}
    }
}