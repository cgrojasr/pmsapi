using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UPC.PMS.BL;

namespace UPC.PMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorBL colaboradorBL;

        public ColaboradorController()
        {
            colaboradorBL = new ColaboradorBL();
        }

        [HttpGet("cbpoactivos")]
        public IActionResult ListarProductOwnersActivos(){
            try
            {
                return Ok(colaboradorBL.ListarProductOwnersActivos());   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cbpmactivos")]
        public IActionResult ListarProjectManagersActivos(){
            try
            {
                return Ok(colaboradorBL.ListarProjectManagersActivos());   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}