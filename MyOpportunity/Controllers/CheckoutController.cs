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
            return View(db.ContactInformation.ToList());
        }

        //
        // GET: /Buyer/Details/5

        public ActionResult Details(int id = 0)
        {
            ContactInformation contactInfo = db.ContactInformation.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
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
        public ActionResult Create(ContactInformation contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.ContactInformation.Add(contactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactInfo);
        }

        //
        // GET: /Buyer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ContactInformation buyer = db.ContactInformation.Find(id);
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
        public ActionResult Edit(ContactInformation contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInfo);
        }

        //
        // GET: /Buyer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ContactInformation buyer = db.ContactInformation.Find(id);
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
            ContactInformation buyer = db.ContactInformation.Find(id);
            db.ContactInformation.Remove(buyer);
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