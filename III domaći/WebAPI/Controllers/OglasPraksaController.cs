using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OglasPraksaController : ControllerBase
{
    [HttpGet("PreuzmiOglasPrakse/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetOglasPrakse(int id)
    {
        try
        {
            OglasPraksaBasic oglas = DTOManager.vratiOglasPrakse(id);

            if (oglas == null)
            {
                return BadRequest($"Podaci o praksi za oglas sa ID={id} ne postoje.");
            }

            return Ok(oglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasPraksu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasPraksu([FromBody] OglasPraksaBasic oglas)
    {
        try
        {
            OglasPraksaBasic izmenjeniOglas = DTOManager.izmeniOglasPraksu(oglas);

            return Ok(izmenjeniOglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
