using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Seller
    {
        //
        [Display(Name = "Id")]
        public string _id { get; set; }
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [Display(Name = "Porciento de Comision")]
        public string comission_percent { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
    }
}
