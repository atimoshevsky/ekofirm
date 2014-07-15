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
    public class CheckoutController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();

        //
        // GET: /Buyer/

        public ActionResult Index()
        {
            return View(db.Buyers.ToList());
        }

        //
        // GET: /Buyer/Details/5

        public ActionResult Details(int id = 0)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        //
        // GET: /Buyer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Buyer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Buyers.Add(buyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buyer);
        }

        //
        // GET: /Buyer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        //
        // POST: /Buyer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyer);
        }

        //
        // GET: /Buyer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        //
        // POST: /Buyer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buyer buyer = db.Buyers.Find(id);
            db.Buyers.Remove(buyer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}