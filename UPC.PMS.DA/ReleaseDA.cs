using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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

        public IEnumerable<ReleaseModel.ListarPorProyecto> ListarPorProyecto(int id_proyecto){
            try
            {
                using (conn){
                    var query = "SELECT REL.id_release, REL.nombre, "+
                                "ISNULL(CONVERT(VARCHAR(20),DET.fecha_inicio, 3),'TBD') AS fecha_inicio, "+
                                "ISNULL(CONVERT(VARCHAR(20),DET.fecha_final, 3),'TBD') AS fecha_final "+
                                "FROM release REL "+
                                "LEFT JOIN release_detalle DET ON REL.id_release = DET.id_release AND DET.activo = 1 "+
                                $"WHERE REL.id_proyecto = {id_proyecto}";

                    return conn.Query<ReleaseModel.ListarPorProyecto>(query);
                }
            }
            catch (SqlException)
            {
                throw new Exception(MessageHelper.mensajeErrorSQL);
            }
        }
    }
}