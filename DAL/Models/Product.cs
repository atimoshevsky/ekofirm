using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Название продукта")]
        public string ProductName { get; set; }


        [Required]
        [StringLength(10000)]
        [DisplayName("Описание")]
        public string Description { get; set; }


        [StringLength(2500)]
        [DisplayName("Краткое описание")]
        public string ShortDescription { get; set; }

        [Required]
        [Range(1, 500)]
        [DisplayName("Цена")]
        public double Price { get; set; }

        [Required]
        [DisplayName("Описание к цене")]
        [StringLength(100)]
        public string PriceClerification { get; set; }

        [Required]
        [DisplayName("Путь к картинке*. Пример: /images/products/Milk/Goat/Milk.jpg")]
        public string ImageUrl { get; set; }

        [DisplayName("Влючить к сезонным")]
        [DefaultValue(false)]
        public bool IncludeToSeason { get; set; }

        [DisplayName("Опубликовать")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(50)]
        [DisplayName("Код*")]
        public string Code { get; set; }

        public int CategoryID { get; set; }


        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
