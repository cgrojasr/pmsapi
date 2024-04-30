using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PMS.DA.Entities;

namespace UPC.PMS.DA
{
    public class ProyectoDA
    {
        private readonly SqlConnection conn;
        public ProyectoDA()
        {
            //conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=password; TrustServerCertificate=true");
            conn = new SqlConnection("Server=localhost; Database=dbProjectEfficiency; User Id=sa; Password=Password@123; TrustServerCertificate=true");
        }

        public List<ProyectoEntity> ListarTodo() {
            var query = "SELECT * FROM proyecto";
            using (conn) { 
                var proyectos = conn.Query<ProyectoEntity>(query).ToList();
                return proyectos;
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
                $"id_po_asignado = {proyecto.id_po_asignado} "+
                $"presupuesto = {proyecto.presupuesto} "+
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
