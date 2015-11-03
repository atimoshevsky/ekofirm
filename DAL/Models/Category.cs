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

        private string _actionName = "ProductList";
        private string _controller = "Product";
       
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Name of category")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Code*")]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Action*")]
        public string ActionName
        {
            get { return _actionName; }
            set { _actionName = value; }
        }

        [Required]
        [StringLength(50)]
        [DisplayName("Controller*")]
        public string ControllerName
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
