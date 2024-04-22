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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProyectoEntity>> ListarTodo() {
            try
            {
                var proyectoBL = new ProyectoBL();
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
                var proyectoBL = new ProyectoBL();
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
                var proyectoBL = new ProyectoBL();
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
            var proyectoBL = new ProyectoBL();
            return Ok(proyectoBL.Registrar(proyecto));
        }
    }
}
