﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyOpportunity.Models
{
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int OrderStatus { get; set; }

        public ContactInformation ContactInformation { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}