using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OglasPrivremeniController : ControllerBase
{
    [HttpGet("PreuzmiOglasPrivremeni/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetOglasPrivremeni(int id)
    {
        try
        {
            OglasPrivremeniBasic oglas = DTOManager.vratiOglasPrivremeni(id);

            if (oglas == null)
            {
                return BadRequest($"Podaci o privremenom oglasu sa ID={id} ne postoje.");
            }

            return Ok(oglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasPrivremeni")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasPrivremeni([FromBody] OglasPrivremeniBasic oglas)
    {
        try
        {
            if (oglas.DatumPocetka > oglas.DatumZavrsetka)
            {
                return BadRequest("Datum početka ne može biti posle datuma završetka.");
            }

            OglasPrivremeniBasic izmenjeniOglas = DTOManager.izmeniOglasPrivremeni(oglas);

            return Ok(izmenjeniOglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
