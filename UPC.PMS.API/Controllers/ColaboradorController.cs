using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UPC.PMS.BL;
using UPC.PMS.DA.Models;

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
        
        [HttpPost("autenticar")]

        public IActionResult Autenticar([FromBody] ColaboradorModel.Autenticar credenciales){
            try
            {
                return Ok(colaboradorBL.Autenticar(credenciales)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("token")]
        public IActionResult Token(int id_colaborador){
            try
            {
                return Ok(colaboradorBL.Token(id_colaborador));   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}