using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyect1.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}