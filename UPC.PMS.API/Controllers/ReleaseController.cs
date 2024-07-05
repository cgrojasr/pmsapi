using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPC.PMS.BL;

namespace UPC.PMS.API;

[ApiController]
[Route("api/[controller]")]
public class ReleaseController : ControllerBase
{
    [HttpGet("ListarPorProyecto/{id_proyecto}")]
    public ActionResult ListarPorProyecto(int id_proyecto){
        try
        {
            var releaseBL = new ReleaseBL();
            return Ok(releaseBL.ListarPorProyecto(id_proyecto));
        }
        catch (System.Exception)
        {
            return BadRequest("Error inesperado");
        }
    }
}
