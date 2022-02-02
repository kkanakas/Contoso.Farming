using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Retail.Functions
{
    public class Retail
    {
        public string Group { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public RetailReading LastReading { get; set; }
    }
}
