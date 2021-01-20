using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyEntities
{
    public class Rate
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }

        public Rate() { }
        public Rate(string currency, string code, double mid)
        {
            Currency = currency;
            Code = code;
            Mid = mid;
        }
    }
}
