using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PMS.DA.Tools
{
    public class HelperConnection
    {
        //private readonly ConfigurationBuilder _configurationBuilder;
        public HelperConnection()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var _configurationBuilder = builder.Build();
#pragma warning disable CS8601 // Possible null reference assignment.
            connectionString = _configurationBuilder.GetConnectionString("dbProjectEfficiency");
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public string connectionString { get;}
    }
}
