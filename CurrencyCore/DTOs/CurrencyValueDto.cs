using CurrencyEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyCore.DTOs
{
    public class CurrencyValueDto
    {
        public Rate Rate { get; set; }
        public double Value { get; set; }

        public CurrencyValueDto(string currency, string code, double mid, double value)
        {
            Rate = new Rate(currency, code, mid);
            Value = value;
        }
    }
}
