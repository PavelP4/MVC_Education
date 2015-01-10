using MvcApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp1.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}