using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPC.PMS.DA.Models
{
    public class GenericModel
    {
        public class DropDownList {
            public int value { get; set; }
            public string text { get; set; } = string.Empty;
        }
    }
}