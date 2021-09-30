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

namespace Xiaomi.Retail.Functions
{
    public static class RetailFunctions
    {
        [OpenApiOperation(operationId: nameof(GetCurrentRetailValues),
          Visibility = OpenApiVisibilityType.Important)
        ]
        [OpenApiResponseWithBody(HttpStatusCode.OK,
            "application/json",
            typeof(Retail[]))]
        [FunctionName(nameof(GetCurrentRetailValues))]
        public static IActionResult GetCurrentRetailValues(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            // get the sensor data from the source
            var retails = GetRetailData();

            // return the result
            return new OkObjectResult(retails);
        }

        static List<Retail> GetRetailData()
        {
            var retails = new List<Retail>();
            for (int i = 0; i < 30; i++)
            {
                retails.Add(new Retail
                {
                    Group = "Phone",
                    LastReading = new RetailReading
                    {
                         SKU = new Random().Next(0,1000000)*10,
                        SerialNum= DateTime.Now
                    },
                    Name = $"SKU-{i}",
                    Type = "Phone SKU"
                });

                retails.Add(new Retail
                {
                    Group = "Serial Number",
                    LastReading = new RetailReading
                    {
                        SKU = new Random().Next(0, 1000000) *100,
                        SerialNum = DateTime.Now
                    },
                    Name = $"SerialNum-{i}",
                    Type = "Serial Number"
                });
            }
            return retails;
        }
    }
}

