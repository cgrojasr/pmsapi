using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPC.PMS.BL;
using UPC.PMS.DA.Entities;

namespace UPC.PMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoBL proyectoBL;

        public ProyectoController()
        {
            proyectoBL = new ProyectoBL();
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

        [HttpGet("buscar2/{id_proyecto}")]
        public ActionResult<ProyectoEntity> BuscarPorId2(int id_proyecto)
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
