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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public HelperConnection()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
