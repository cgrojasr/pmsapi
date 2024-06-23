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
            conn = new SqlConnection(ConnectionHelper.GetConnectionString());
        }

        public List<ProyectoEntity> ListarTodo() {
            var query = "SELECT * FROM proyecto";
            using (conn) { 
                var proyectos = conn.Query<ProyectoEntity>(query).ToList();
                return proyectos;
            }
        }

        public List<ProyectoModel.ListarPorPM> ListarPorPM(int id_pm){
            try
            {
                var query = "SELECT PRO.id_proyecto, PRO.codigo, PRO.nombre, ETP.nombre AS etapa, EST.nombre AS estado, CHP.nombre AS chapter_programa "+
                            "FROM proyecto PRO "+
                            "INNER JOIN etapa_proyecto ETP ON PRO.id_etapa = ETP.id_etapa "+
                            "INNER JOIN estado_proyecto EST ON PRO.id_estado = EST.id_estado "+
                            "INNER JOIN chapter_programa CHP ON PRO.id_chapter_programa = CHP.id_chapter_programa "+
                            $"WHERE PRO.id_estado <> 6 AND PRO.id_pm_responsable = {id_pm} "+
                            "UNION "+
                            "SELECT PRO.id_proyecto, PRO.codigo, PRO.nombre, ETP.nombre AS etapa, EST.nombre AS estado, CHP.nombre AS chapter_programa "+
                            "FROM proyecto_pm_equipo TEM "+
                            "INNER JOIN proyecto PRO ON TEM.id_proyecto = PRO.id_proyecto "+
                            "INNER JOIN etapa_proyecto ETP ON PRO.id_etapa = ETP.id_etapa "+
                            "INNER JOIN estado_proyecto EST ON PRO.id_estado = EST.id_estado "+
                            "INNER JOIN chapter_programa CHP ON PRO.id_chapter_programa = CHP.id_chapter_programa "+
                            $"WHERE PRO.id_estado <> 6 AND TEM.id_pm_colaborador =  {id_pm} "+
                            "ORDER BY 1 DESC";
            
                using(conn){
                    var result = conn.Query<ProyectoModel.ListarPorPM>(query).ToList();
                    return result;
                }   
            }
            catch (SqlException){
                throw new Exception(MessageHelper.mensajeErrorSQL);
            }
        }

        public ProyectoEntity BuscarPorId(int id_proyecto) {
            try
            {
                var query = "SELECT PRO.codigo, PRO.nombre, PRO.id_chapter_programa, PRO.id_naturaleza, PRO.id_pm_responsable, "+
                        "PRO.presupuesto_inicial, PRO.id_etapa, PRO.id_estado "+
                        $"FROM proyecto PRO WHERE PRO.id_proyecto = {id_proyecto}";
                using (conn)
                {
                    var proyecto = conn.QuerySingle<ProyectoEntity>(query);
                    return proyecto;
                }   
            }
            catch (SqlException)
            {
                throw new Exception(MessageHelper.mensajeErrorSQL);
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
                $"id_pm_asignado = {proyecto.id_pm_responsable} "+
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
