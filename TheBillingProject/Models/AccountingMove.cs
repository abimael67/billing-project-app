using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TheBillingProject.Models
{
    public class AccountingMove
    {
        [Display(Name = "Id")]
        public string _id { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Aux")]
        public string aux { get; set; }
        [Display(Name = "Date")]
        public string date { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Details")]
        public List<AccountingMoveDetail> details { get; set; }
    }
}