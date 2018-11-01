using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Article
    { 
        //
        public string _id { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public double unit_price { get; set; }
    }
}