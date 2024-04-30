using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPC.PMS.DA;
using UPC.PMS.DA.Models;

namespace UPC.PMS.BL
{
    public class ColaboradorBL
    {
        private readonly ColaboradorDA colaboradorDA;

        public ColaboradorBL()
        {
            colaboradorDA = new ColaboradorDA();
        }

        public List<ColaboradorModel.ProductOwnerActivo> ListarProductOwnersActivos(){
            try
            {
                var colaboradores = colaboradorDA.ListarProductOwnersActivos();   
                if(colaboradores.Count() == 0)
                    throw new Exception("No se encontraron product owners");
                else
                    return colaboradores;
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public List<ColaboradorModel.ProjectManagerActivo> ListarProjectManagersActivos(){
            try
            {
                var colaboradores = colaboradorDA.ListarProjectManagersActivos();   
                if(colaboradores.Count() == 0)
                    throw new Exception("No se encontraron project managers");
                else
                    return colaboradores;
            }
            catch (Exception)
            {   
                throw;
            }
        }
    }
}