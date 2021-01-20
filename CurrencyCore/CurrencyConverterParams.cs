using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurrencyCore
{
    public class CurrencyConverterParams
    {
        [Required]
        public string CodeFrom { get; set; }
        [Required]
        public string CodeTo { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
