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

        
        [HttpGet("ListarPorPM/{id_pm}")]
        public ActionResult<List<ProyectoModel.ListarPorPM>> ListarPorPM(int id_pm){
            try
            {
                return Ok(proyectoBL.ListarPorPM(id_pm)); 
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
