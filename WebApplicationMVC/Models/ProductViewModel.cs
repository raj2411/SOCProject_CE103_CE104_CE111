using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVC.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public float price { get; set; }
        public int qty { get; set; }
        public DateTime datecreated { get; set; }

    }
}