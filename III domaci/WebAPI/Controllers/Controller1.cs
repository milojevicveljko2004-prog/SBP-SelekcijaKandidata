using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DatabaseAccess;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller1:ControllerBase
    {
        [HttpGet]
        [Route("Preuzmi prodavnice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProdavnice()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveProdavnice);
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("DodajProdavnicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddProdavnica([FromBody]ProdavnicaView prodavnica)
        {
            try
            {
                DataProvider.DodajProdavnicu(prodavnica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("PromeniProdavnicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeProdavnica([FromBody] ProdavnicaView prodavnica)
        {
            try
            {
                DataProvider.AzurirajProdavnicu(prodavnica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiProdavnicu/{prodavnicaID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteProdavnica([FromRoute(Name ="prodavnicaID")]int id)
        {
            try
            {
                DataProvider.ObrisiProdavnicu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
