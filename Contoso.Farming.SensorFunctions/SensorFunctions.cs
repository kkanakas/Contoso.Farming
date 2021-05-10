using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Contoso.Farming.SensorFunctions
{
    public static class SensorFunctions
    {
        [OpenApiOperation(operationId: nameof(GetCurrentSensorValues),
          Visibility = OpenApiVisibilityType.Important)
        ]
        [OpenApiResponseWithBody(HttpStatusCode.OK,
            "application/json",
            typeof(Sensor[]))]
        [FunctionName(nameof(GetCurrentSensorValues))]
        public static IActionResult GetCurrentSensorValues(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            // get the sensor data from the source
            var sensors = GetSensorData();

            // return the result
            return new OkObjectResult(sensors);
        }

        static List<Sensor> GetSensorData()
        {
            var sensors = new List<Sensor>();
            for (int i = 0; i < 30; i++)
            {
                sensors.Add(new Sensor
                {
                    Group = "Soil Humidity",
                    LastReading = new SensorReading
                    {
                        Reading = new Random().NextDouble(),
                        Timestamp = DateTime.Now
                    },
                    Name = $"soil-{i}",
                    Type = "Soil"
                });

                sensors.Add(new Sensor
                {
                    Group = "Temperature",
                    LastReading = new SensorReading
                    {
                        Reading = new Random().NextDouble(),
                        Timestamp = DateTime.Now
                    },
                    Name = $"temp-{i}",
                    Type = "Temperature"
                });
            }
            return sensors;
        }
    }
}

