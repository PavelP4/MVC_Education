using System;
using System.Collections.Generic;


namespace MvcApp1.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
