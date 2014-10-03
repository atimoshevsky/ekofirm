using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyOpportunity.Models
{
    public class OdeToFoodDb :DbContext
    {

        public OdeToFoodDb()
            : base("DefaultConnection")
        { }
        public DbSet<Restaurant> Restaurants{ get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }


    } 
}