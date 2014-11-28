using BusinessLogic.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOpportunity.Areas.Admin.Controllers
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

        //
        // GET: /CategoryReview/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoryReview/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _catalogService.CreateCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //
        // GET: /CategoryReview/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var category = _catalogService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /CategoryReview/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _catalogService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /CategoryReview/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var category = _catalogService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /CategoryReview/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _catalogService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
