using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PMS.DA.Entities
{
    public class ProyectoEntity
    {
        public int id_proyecto { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public int id_chapter_programa { get; set; }
        public int id_naturaleza { get; set; }
        public int id_pm_asignado { get; set; }
        public float presupuesto_inicial { get; set; }
        public int id_etapa { get; set; }
        public int id_estado { get; set; }
    }
}
