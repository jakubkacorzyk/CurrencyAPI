using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyEntities
{
    public class CurrencyRate
    {
        public string No { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double Mid { get; set; }
    }
}
