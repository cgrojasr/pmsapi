using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPC.PMS.DA.Models
{
    public class ProyectoModel
    {
        public class ListarActivo {
            public int id_proyecto { get; set; }
            public string codigo { get; set; } = string.Empty;
            public string nombre { get; set; } = string.Empty;
            public string pm_asignado { get; set; } = string.Empty;
            public string etapa { get; set; } = string.Empty;
            public string estado { get; set; } = string.Empty;
        }
    }
}