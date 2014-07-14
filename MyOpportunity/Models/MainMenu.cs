using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOpportunity.Models
{
    public class MainMenu
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}