using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOpportunity.Common;
using MyOpportunity.Models;

namespace MyOpportunity.Controllers
{
    public class OrderController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();

        //
        // POST: /Order/Create
        public ActionResult Create(Order order)
        {
            try
            {
                if (Request.IsAjaxRequest())
                {
                    order.DateCreated = DateTime.UtcNow;
                    order.OrderStatus = (int)Constants.OrderStatus.Ordered;
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            { 
                // log exception  here
                return Json(new { Result = "Failed" });
            }
            
        }

        //

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}