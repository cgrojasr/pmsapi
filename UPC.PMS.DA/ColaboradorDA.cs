using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using UPC.PMS.DA.Entities;
using UPC.PMS.DA.Models;
using UPC.PMS.DA.Tools;

namespace UPC.PMS.DA
{
    public class ColaboradorDA
    {
        private readonly SqlConnection conn;
        public ColaboradorDA()
        {
            conn = new SqlConnection(ConnectionHelper.GetConnectionString());
        }

        public IEnumerable<ColaboradorModel.DropDownList> ListarProjectManagersActivos(){
            try
            {
                var query = "SELECT id_colaborador AS value, (nombre + ' ' + apellidos) AS text "+
                            "FROM colaborador "+
                            "WHERE activo = 1 AND id_rol = 1";
                using(conn){
                    return conn.Query<ColaboradorModel.DropDownList>(query);
                }   
            }
            catch (SqlException)
            {
                throw new Exception(MessageHelper.mensajeErrorSQL);
            }
        }

        public int Autenticar(ColaboradorModel.Autenticar credenciales){
            try
            {
                var query = "SELECT id_colaborador FROM colaborador "
                            +$"WHERE correo = {credenciales.correo} AND contrasena = {credenciales.contrasena}";
                
                using (conn)
                {
                    return conn.ExecuteScalar<int>(query);
                }
            }
            catch (SqlException)
            {
                throw new Exception(MessageHelper.mensajeErrorSQL);
            }
        }

        public ColaboradorModel.Token Token(int id_colaborador){
            try
            {
                var query = "SELECT id_colaborador, nombre, apellidos "+
                            "FROM colaborador "+
                            $"WHERE id_colaborador = {id_colaborador}";
                
                using (conn)
                {
                    return conn.QuerySingle<ColaboradorModel.Token>(query);
                }
            }
            catch (SqlException)
            {
                throw new Exception(MessageHelper.mensajeErrorSQL);
            }
        }
    }
}