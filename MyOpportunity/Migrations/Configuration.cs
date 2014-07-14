namespace MyOpportunity.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyOpportunity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MyOpportunity.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyOpportunity.Models.OdeToFoodDb context)
        {
            
        }
    }
}

