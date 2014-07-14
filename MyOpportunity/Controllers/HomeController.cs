using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOpportunity.Models;

namespace MyOpportunity.Controllers
{
    public class HomeController : Controller, IDisposable
    {

        private OdeToFoodDb m_db = new OdeToFoodDb();

        [ChildActionOnly]
        [OutputCache(Duration=500)]
        public ActionResult MainMenu()
        {
            var categoryMenuModel = m_db.Categories.Select(c => new MainMenu { 
                ActionName = c.ActionName, 
                ControllerName = c.ControllerName, 
                Title = c.CategoryName,
                CategoryID = c.CategoryID
            }).ToList();

            return PartialView("_MainMenu", categoryMenuModel);
        }

        [ChildActionOnly]
        public ActionResult SeasonProducts()
        {
            var seasonProducts = m_db.Products.Where(p => p.IncludeToSeason == true && p.IsActive == true).ToList();
            return PartialView("_SeasonProducts", seasonProducts);
        }

        public ActionResult Index()
        {

            var review = m_db.Products.Where(r => r.IsActive == true).Take(10);

            return View(review);
        } 

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (m_db != null)
                m_db.Dispose();

            base.Dispose(disposing);
        }
    }
}
