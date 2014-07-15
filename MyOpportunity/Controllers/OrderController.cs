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
    public class OrderController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();

        //
        // POST: /Order/Create
        public ActionResult Create(Order order)
        {
            Order temoOrder = new Order();

            temoOrder.Buyer = new Buyer() { Email = "alexander.timoshevsky@gmail.com", Name = "Alex", PhoneNumber = "0978838505" };
            temoOrder.DateCreated = DateTime.Now;
            temoOrder.OrderDetails = new List<OrderDetails>();
            temoOrder.OrderDetails.Add(new OrderDetails() { Discount = 0, Price = 30, Quantity = 4 });

            return Json(temoOrder);
        }

        //

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}