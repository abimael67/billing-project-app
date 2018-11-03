using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Clients
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "RNC or id")]
        public string rnc { get; set; }
        [Display(Name = "Account")]
        public string account { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }

    }
}