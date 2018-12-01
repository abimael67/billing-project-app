using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Bill
    {
        //
        [Display(Name = "Id")]
        public string _id { get; set; }
        [Display(Name = "Seller Id")]
        public string seller { get; set; }
        [Display(Name = "Client Id")]
        public string customer { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Display(Name = "Commentario")]
        public string comment { get; set; }
        public List<BillDetails> details;
    }
    public class BillDetails
    {
        public string _id { get; set; }
        public string article { get; set; }
        public string amount { get; set; }
        public string unit_price { get; set; }
     
    }
}