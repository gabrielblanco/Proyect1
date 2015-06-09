using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect1.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}