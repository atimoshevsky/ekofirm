using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Seller
    {
        public int SellerID { get; set; }
        public string Username{ get; set; }

        public virtual List<Item> Arts { get; set; }
    }

    public class Item   
    {
        public int ItemID { get; set; }
        public string Title{ get; set; }
        public string Desciprion { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
    }
}

