using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPC.PMS.DA.Models
{
    public class ColaboradorModel
    {
        public class DropDownList : GenericModel.DropDownList{}

        public class Token {
            public int id_colaborador { get; set; }
            public string nombre { get; set; } = string.Empty;
            public string apellidos { get; set; } = string.Empty;
        }

        public class Autenticar{
            public string correo { get; set; } = string.Empty;
            public string contrasena { get; set; } = string.Empty;
        }
    }
}