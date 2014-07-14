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
    public class RestaurantController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();


        public ActionResult Autocomplete(string term)
        {
            var model = db.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new 
                    {
                        label = r.Name,
                    });
                    

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Restaurant/

        public ActionResult Index(string searchName = null)
        {
            var model = (from r in db.Restaurants
                         where (searchName == null || r.Name.StartsWith(searchName))
                        select new SimpleRestaurantReview
                        {
                            RestaurantId = r.Id,
                            Country = r.Country,
                            RestaurantName = r.Name,
                            TotalReviewCounts = r.Reviews.Count(),
                            AvarageRating = r.Reviews.Average(rew => rew.Rating)
                        }).Take(100);

            if (Request.IsAjaxRequest())
                return PartialView("_Restaurants", model);

            return View(model);
        }


        //
        // GET: /Restaurant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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