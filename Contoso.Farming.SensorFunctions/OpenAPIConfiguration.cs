using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Retail.Functions
{
    public class OpenAPIConfiguration : IOpenApiConfigurationOptions
    {
        public OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = "1.0.0",
            Title = "Inventory Application",
            Description = "Functions used to query product SKUs",
            Contact = new OpenApiContact()
            {
                Name = "Contoso Retail",
                Email = "Contoso-Retail@support.com"
            }
        };

        public List<OpenApiServer> Servers
        {
            get
            {
                return (new OpenApiServer[] { new OpenApiServer { Url =
                    Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME")
                }}).ToList();
            }
            set => throw new NotImplementedException();
        }

        public OpenApiVersionType OpenApiVersion { get => OpenApiVersionType.V2; set => throw new NotImplementedException(); }
        public bool IncludeRequestingHostName { get => true; set => throw new NotImplementedException(); }
    }
}
