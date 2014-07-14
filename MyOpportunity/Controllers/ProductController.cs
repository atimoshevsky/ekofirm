using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOpportunity.Models;

namespace MyOpportunity.Controllers
{
    public class ProductController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();


        public ActionResult ProductList([Bind(Prefix = "id")] int categoryId)
        {
            var products = db.Categories.Find(categoryId);

            if (products == null)
            {
                return HttpNotFound();
            }

            return View(products);
        }
         //
        // GET: /Reviews/
        public ActionResult Index([Bind(Prefix = "id")]int categoryId)
        {
            var products = db.Categories.Find(categoryId);
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
                product.DateCreated = DateTime.UtcNow;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = product.CategoryID });
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
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
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = product.CategoryID });
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
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
            Product product = db.Products.Find(id);
            var categoryID = product.CategoryID;
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = categoryID});
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}