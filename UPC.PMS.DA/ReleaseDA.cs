using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UPC.PMS.DA
{
    public class ReleaseDA
    {
        private readonly SqlConnection conn;

        public ReleaseDA()
        {
            conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=P@$$w0rD; TrustServerCertificate=true");
        }

        
    }
}