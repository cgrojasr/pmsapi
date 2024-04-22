﻿using UPC.PMS.DA;
using UPC.PMS.DA.Entities;

namespace UPC.PMS.BL
{
    public class ProyectoBL
    {
        private readonly ProyectoDA proyectoDA;
        public ProyectoBL()
        {
            proyectoDA = new ProyectoDA();
        }

        public List<ProyectoEntity> ListarTodo() {
            try
            {
                var proyectos = proyectoDA.ListarTodo();
                if (proyectos.Count == 0)
                    throw new Exception("No se encontraron proyectos");

                return proyectos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProyectoEntity BuscarPorId(int id_proyecto) {
            try
            {
                var proyecto = proyectoDA.BuscarPorId(id_proyecto);
                return proyecto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProyectoEntity Registrar(ProyectoEntity proyecto)
        {
            return proyectoDA.Registrar(proyecto);
        }
    }
}
