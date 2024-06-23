using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UPC.PMS.DA.Tools;

namespace UPC.PMS.DA
{
    public class ReleaseDA
    {
        private readonly SqlConnection conn;

        public ReleaseDA()
        {
            conn = new SqlConnection(ConnectionHelper.GetConnectionString());
        }

        
    }
}