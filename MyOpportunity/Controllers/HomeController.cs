using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOpportunity.Models;
using DAL.Generic;
using BusinessLogic.Interfaces;

namespace MyOpportunity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogService _catalogService;

        public HomeController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var categoryMenuModel = _catalogService.GetCategories().Select(c => new MainMenu
            { 
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
            var seasonProducts = _catalogService.GetSeasonProducts();
            return PartialView("_SeasonProducts", seasonProducts);
        }

        public ActionResult Index()
        {
            var review = _catalogService.GetProducts();

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
       
    }
}
