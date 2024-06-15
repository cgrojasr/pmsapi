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
            connectionString = _configurationBuilder.GetConnectionString("dbProjectEfficiency");
        }

        public string connectionString { get;}
    }
}
