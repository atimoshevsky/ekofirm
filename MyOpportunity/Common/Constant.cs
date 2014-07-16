using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOpportunity.Common
{
    public class Constants
    {
        public enum OrderStatus
        {
            Ordered = 1,// ordered via web site
            Approved = 2, // approved after calling o customer
            Canceled = 3, // canceled
            Dilivered = 4 // delivered to customer
        }
    }
}