﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBillingProject.Models
{
    public class Customer
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string identification { get; set; }
        public string account { get; set; }
        public int __v { get; set; }
    }
}