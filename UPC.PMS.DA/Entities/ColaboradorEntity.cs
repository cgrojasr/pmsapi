using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPC.PMS.DA.Entities
{
    public class ColaboradorEntity
    {
        public int id_colaborador { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellidios { get; set; } = string.Empty;
        public int id_rol { get; set; }
        public string usuario { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public bool activo { get; set; }
    }
}