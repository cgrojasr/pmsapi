using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UPC.PMS.DA.Tools
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString(){
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var _configurationBuilder = builder.Build();
#pragma warning disable CS8603 // Possible null reference return.
            return _configurationBuilder.GetConnectionString("dbProjectEfficiency");
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}