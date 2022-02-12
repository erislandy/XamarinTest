using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class PriceModel : IComparable
    {
        public double Price { get; set; }
        public string Motive { get; set; }

        public int CompareTo(object obj)
        {
            PriceModel p = (PriceModel)obj;
            return this.Price.CompareTo(p.Price);
        }
    }
}
