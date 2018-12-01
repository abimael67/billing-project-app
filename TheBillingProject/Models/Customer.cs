using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Customer
    {
        //
        [Display(Name = "Id")]
        public string _id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Acount")]
        public string account { get; set; }
        [Display(Name = "Identitfication")]
        public string identification { get; set; }
    }
}