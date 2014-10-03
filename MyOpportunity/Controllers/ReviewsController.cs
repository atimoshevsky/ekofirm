using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOpportunity.Models;
using System.Data;
using System.Data.Entity;

namespace MyOpportunity.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb m_db = new OdeToFoodDb();

        //
        // GET: /Reviews/
        public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
        {

            var restaurant = m_db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                m_db.Reviews.Add(review);
                m_db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = m_db.Reviews.Find(id);
            if (model != null)
            {
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                m_db.Entry(review).State = EntityState.Modified;
                m_db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }
        //
        // GET: /Reviews/Details/5


        protected override void Dispose(bool disposing)
        {
            if (m_db != null)
            {
                m_db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
