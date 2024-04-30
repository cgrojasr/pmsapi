using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using UPC.PMS.DA.Entities;
using UPC.PMS.DA.Models;

namespace UPC.PMS.DA
{
    public class ColaboradorDA
    {
        private readonly SqlConnection conn;
        public ColaboradorDA()
        {
            conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=Password@123; TrustServerCertificate=true");
        }

        public List<ColaboradorModel.ProjectManagerActivo> ListarProjectManagersActivos(){
            var query = "SELECT id_colaborador AS value, (nombre + ' ' + apellidos) AS text FROM colaborador WHERE activo = 1 AND id_rol = 1";
            using(conn){
                return conn.Query<ColaboradorModel.ProjectManagerActivo>(query).ToList();
            }
        }

        public List<ColaboradorModel.ProductOwnerActivo> ListarProductOwnersActivos(){
            try
            {
                var query = "SELECT id_colaborador AS value, (nombre + ' ' + apellidos) AS text FROM colaborador WHERE activo = 1 AND id_rol = 2";
                using(conn){
                    return conn.Query<ColaboradorModel.ProductOwnerActivo>(query).ToList();
                }
            }
            catch (SqlException)
            {
                throw new Exception("Error al consultar en la base de datos");
            }
        }
    }
}