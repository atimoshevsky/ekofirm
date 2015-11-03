using BusinessLogic.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOpportunity.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CategoryController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        //
        // GET: /CategoryReview/

        public ActionResult Index()
        {
            return View(_catalogService.GetCategories());
        }

        public ActionResult CategoryList()
        {
            return View(_catalogService.GetCategories());
        }

        //
        // GET: /CategoryReview/Details/5

        public ActionResult Details(int id = 0)
        {
            var category = _catalogService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
       
    }
}
