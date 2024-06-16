using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PMS.DA.Entities;
using UPC.PMS.DA.Models;
using UPC.PMS.DA.Tools;

namespace UPC.PMS.DA
{
    public class ProyectoDA
    {
        private readonly SqlConnection conn;
        public ProyectoDA()
        {
            //conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=password; TrustServerCertificate=true");
            //conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=P@$$w0rD; TrustServerCertificate=true");
            conn = new SqlConnection(new HelperConnection().connectionString);
        }

        public List<ProyectoEntity> ListarTodo() {
            var query = "SELECT * FROM proyecto";
            using (conn) { 
                var proyectos = conn.Query<ProyectoEntity>(query).ToList();
                return proyectos;
            }
        }

        public List<ProyectoModel.ListarPorPMASignado> ListarPorPMASignado(int id_pm_asignado){
            try
            {
                var query = $"SELECT PRO.id_proyecto, PRO.codigo, PRO.nombre, ETP.nombre AS etapa, EST.nombre AS estado "+
                        "FROM proyecto PRO "+
                        "INNER JOIN etapa_proyecto ETP ON PRO.id_etapa = ETP.id_etapa "+
                        "INNER JOIN estado_proyecto EST ON PRO.id_estado = EST.id_estado "+
                        $"WHERE PRO.id_estado <> 6 AND PRO.id_pm_asignado = {id_pm_asignado}";
            
                using(conn){
                    var result = conn.Query<ProyectoModel.ListarPorPMASignado>(query).ToList();
                    return result;
                }   
            }
            catch (SqlException ex){
                throw new Exception("Error en el script de la base de datos o en la conexión a la misma");
            }
        }

        public ProyectoEntity BuscarPorId(int id_proyecto) {
            var query = $"SELECT * FROM proyecto WHERE id_proyecto = {id_proyecto}";
            using (conn)
            {
                var proyecto = conn.Query<ProyectoEntity>(query).Single();
                return proyecto;
            }
        }

        public ProyectoEntity Registrar(ProyectoEntity proyecto) {
            //var query = $"INSERT proyecto VALUES ('{proyecto.nombre}', {proyecto.id_pm_asignado}, {proyecto.id_po_asignado}, {proyecto.presupuesto}) " +
            var query = $"INSERT proyecto VALUES ('{proyecto.nombre}', null, null, null) " +
                $"SELECT SCOPE_IDENTITY()";

            using(conn)
            {
                proyecto.id_proyecto = conn.Query<int>(query).Single();
                return proyecto;
            }
        }

        public ProyectoEntity Modificar(ProyectoEntity proyecto){
            var query = $"UPDATE proyecto SET "+
                $"nombre = '{proyecto.nombre}' "+
                $"id_pm_asignado = {proyecto.id_pm_asignado} "+
                //$"id_po_asignado = {proyecto.id_po_asignado} "+
                //$"presupuesto = {proyecto.presupuesto_inicial} "+
                $"WHERE id_proyecto = {proyecto.id_proyecto}";
            
            using(conn){
                conn.Execute(query);
                return proyecto;
            }
        }

        public bool Eliminar(int id_proyecto){
            try
            {
                var query = $"DELETE FROM proyecto WHERE id_proyecto = {id_proyecto}";
                using(conn){
                    conn.Execute(query);
                }   
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
