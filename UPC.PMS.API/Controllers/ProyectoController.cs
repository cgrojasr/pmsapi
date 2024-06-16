using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPC.PMS.BL;
using UPC.PMS.DA.Entities;
using UPC.PMS.DA.Models;

namespace UPC.PMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoBL proyectoBL;

        public ProyectoController()
        {
            proyectoBL = new ProyectoBL();
        }

        
        [HttpGet("ListarPorPMASignado/{id_pm_asignado}")]
        public ActionResult<List<ProyectoModel.ListarPorPMASignado>> ListarPorPMASignado(int id_pm_asignado){
            try
            {
                return Ok(proyectoBL.ListarPorPMASignado(id_pm_asignado)); 
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProyectoEntity>> ListarTodo() {
            try
            {
                return Ok(proyectoBL.ListarTodo());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id_proyecto}")]
        public ActionResult<ProyectoEntity> BuscarPorId(int id_proyecto)
        {
            try
            {
                return Ok(proyectoBL.BuscarPorId(id_proyecto));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<ProyectoEntity> Registrar([FromBody]ProyectoEntity proyecto)
        {
            return Ok(proyectoBL.Registrar(proyecto));
        }

        [HttpPut]
        public ActionResult<ProyectoEntity> Modificar([FromBody]ProyectoEntity proyecto){
            return Ok(proyectoBL.Modificar(proyecto));
        }

        [HttpDelete("{id_proyecto}")]
        public ActionResult<bool> Eliminar(int id_proyecto){
            return Ok(proyectoBL.Eliminar(id_proyecto));
        }
    }
}
