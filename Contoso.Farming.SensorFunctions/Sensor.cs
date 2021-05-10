using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Farming.SensorFunctions
{
    public class Sensor
    {
        public string Group { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public SensorReading LastReading { get; set; }
    }
}
