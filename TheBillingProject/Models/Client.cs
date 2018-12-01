using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Client
    {
        //
        [Display(Name = "Id")]
        public string _id { get; set; }
        [Display(Name = "Nombre Comercial o Razon Social")]
        public string name { get; set; }
        [Display(Name = "RNC o Cedula")] 
        public string identification { get; set; }
        [Display(Name = "Cuenta Contable")]
        public string account { get; set; }
        [Display(Name = "Estado")]
        public string status { get; set; }
   
    }
}