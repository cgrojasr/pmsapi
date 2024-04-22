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
        public string nombre { get; set; } = string.Empty;
        public int id_pm_asignado { get; set; }
        public int id_po_asignado { get; set; }
        public float presupuesto { get; set; }
    }
}
