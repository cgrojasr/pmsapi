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

        public IEnumerable<ColaboradorModel.DropDownList> ListarProjectManagersActivos(){
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

        public int Autenticar(ColaboradorModel.Autenticar credenciales){
            try
            {
                var id_colaborador = colaboradorDA.Autenticar(credenciales);
                if(id_colaborador == 0)
                    throw new Exception("Correo o contraseña incorrectas");
                return id_colaborador;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ColaboradorModel.Token Token(int id_colaborador){
            try
            {
                return colaboradorDA.Token(id_colaborador);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}