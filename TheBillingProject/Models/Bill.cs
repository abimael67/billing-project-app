using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Bill
    {
        public string _id { get; set; }
        public DateTime date { get; set; }
        public string seller { get; set; }
        public string customer { get; set; }
        public string comment { get; set; }
        public List<BillDetail> details { get; set; }
        public int bill_number { get; set; }
        public int __v { get; set; }
    }
    public class BillDetail
    {
        public string _id { get; set; }
        public string article { get; set; }
        public double amount { get; set; }
        public double unit_price { get; set; }
    }
}