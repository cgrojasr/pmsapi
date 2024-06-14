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
            conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=P@$$w0rD; TrustServerCertificate=true");
        }

        public List<ColaboradorModel.DropDownList> ListarProjectManagersActivos(){
            var query = "SELECT id_colaborador AS value, (nombre + ' ' + apellidos) AS text FROM colaborador WHERE activo = 1 AND id_rol = 1";
            using(conn){
                return conn.Query<ColaboradorModel.DropDownList>(query).ToList();
            }
        }

        public List<ColaboradorModel.DropDownList> ListarProductOwnersActivos(){
            try
            {
                var query = "SELECT id_colaborador AS value, (nombre + ' ' + apellidos) AS text FROM colaborador WHERE activo = 1 AND id_rol = 2";
                using(conn){
                    return conn.Query<ColaboradorModel.DropDownList>(query).ToList();
                }
            }
            catch (SqlException)
            {
                throw new Exception("Error al consultar en la base de datos");
            }
        }
    }
}