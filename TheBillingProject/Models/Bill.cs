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
        public string seller_id { get; set; }
        [Display(Name = "Client Id")]
        public string client_id { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Display(Name = "Commentario")]
        public string comment { get; set; }
        [Display(Name = "Article Id")]
        public string article_id{ get; set; }
        [Display(Name = "Cantidad")]
        public int quantity { get; set; }
        [Display(Name = "Precio Unitario")]
        public int unit_price { get; set; }
        public List<BillDetails> billDetails;
    }
    public class BillDetails
    {
        public string _id { get; set; }
        public string article { get; set; }
        public string amount { get; set; }
        public string unit_price { get; set; }
     
    }
}