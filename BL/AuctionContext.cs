using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace BL
{
    public class AuctionContext: DbContext
    {
        public AuctionContext(string connectionStringName)
            : base(connectionStringName)
        { 
        }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
