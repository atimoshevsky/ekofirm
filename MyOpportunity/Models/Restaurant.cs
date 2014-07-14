using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOpportunity.Models
{

    public class SimpleRestaurantReview
    {

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Country { get; set; }
        public int TotalReviewCounts { get; set; }

        public double? AvarageRating { get; set; }
    }

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<RestaurantReview> Reviews { get; set; }
    }
}