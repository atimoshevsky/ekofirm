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
    public class Category
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Имя категории")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Код*")]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Action*")]
        public string ActionName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Controller*")]
        public string ControllerName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
