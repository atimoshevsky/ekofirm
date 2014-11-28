using BusinessLogic.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOpportunity.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICatalogService _catalogService;


        public ProductController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public ActionResult ProductList([Bind(Prefix = "id")] int categoryId)
        {
            var category = _catalogService.GetCategoryById(categoryId);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
        //
        // GET: /Reviews/
        public ActionResult Index([Bind(Prefix = "id")]int categoryId)
        {
            var products = _catalogService.GetCategoryById(categoryId);
            return View(products);
        }
        //
        // GET: /Product/Create

        public ActionResult Create(int categoryID)
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _catalogService.CreateProduct(product);
                return RedirectToAction("Index", new { id = product.CategoryID });
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var product = _catalogService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _catalogService.UpdateProduct(product);
                return RedirectToAction("Index", new { id = product.CategoryID });
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = _catalogService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var categoryId = _catalogService.GetCategoryIdByProductId(id);
            _catalogService.DeleteProduct(id);
            return RedirectToAction("Index", new { id = categoryId });
        }
    }
}
