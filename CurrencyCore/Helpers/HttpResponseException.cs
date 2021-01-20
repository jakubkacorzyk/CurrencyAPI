using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyCore.Helpers
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; }
        public string Value { get; set; }

        public HttpResponseException(int status, string message) : base(message)
        {
            Status = status;
        }
    }
}
