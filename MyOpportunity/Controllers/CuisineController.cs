using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOpportunity.Filters;

namespace MyOpportunity.Controllers
{
    [Authorize]
    [Log]
    public class CuisineController : Controller
    {
        public ActionResult Search(string name = "french")
        {
            throw new Exception("Something terrivle has happened");
            var message = Server.HtmlEncode(name);

            return Content(message);
        }


        
    }
}
