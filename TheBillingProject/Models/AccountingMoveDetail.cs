using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TheBillingProject.Models
{
    public class AccountingMoveDetail
    {
        [Display(Name = "Account")]
        public int account { get; set; }
        [Display(Name = "Customer")]
        public string customer { get; set; }
        [Display(Name = "Seller")]
        public string seller { get; set; }
        [Display(Name = "Move Type")]
        public string moveType { get; set; }
        [Display(Name = "Total")]
        public double total { get; set; }
    }
}