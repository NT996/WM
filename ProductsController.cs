using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
            };
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                // Ako nije validan, vraćamo korisnika na formu.
                var viewModel = new ProductFormViewModel()
                {
                    Product = _context.Products.SingleOrDefault(p => p.ID == product.ID)
                };
                return View("ProductForm", viewModel);
            }
            if (product.ID == 0)
                _context.Products.Add(product);
            else
            {
                var productInDb = _context.Products.Single(p => p.ID == product.ID);
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Producer = product.Producer;
                productInDb.Supplier = product.Supplier;
                productInDb.Price = product.Price;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public ViewResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public ActionResult Details(int ID)
        {
            var products = _context.Products.SingleOrDefault(p => p.ID == ID);

            if (products == null)
                return HttpNotFound();
            return View(products);
        }

        public ActionResult Edit(int ID)
        {
            var product = _context.Products.SingleOrDefault(p => p.ID == ID);
            if (product == null)
            {
                HttpNotFound();
            }
            var viewModel = new ProductFormViewModel
            {
                Product = product,
            };
            return View("ProductForm", viewModel);
        }
    }
}