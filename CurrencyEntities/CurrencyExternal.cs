using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyEntities
{
    public class CurrencyExternal
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public List<CurrencyRate> Rates { get; set; }
    }
}
