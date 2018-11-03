using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Article
    {
        //
        [Display(Name = "Id")]
        public string _id { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Unit Price")]
        public double unit_price { get; set; }
    }
}