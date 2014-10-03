using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("DefaultConnection")
        {
        }

        public ApplicationDBContext(string connectionString) :
            base(connectionString)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
