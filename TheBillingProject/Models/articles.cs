using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class articles
    {
        public int id { get; set; }
        public string status { get; set; }
        public string _id { get; set; }
        public string description { get; set; }
        public decimal unit_price { get; set; }
        public int __v { get; set; }
    }
}