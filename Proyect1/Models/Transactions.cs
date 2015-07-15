using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect1.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public int FeacturedProduct { get; set; }
        public int ProductOfInterest { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}