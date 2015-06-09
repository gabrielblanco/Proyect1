using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string FeaturedProduct { get; set; }
        public string ProductOfInteres { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
    }
}