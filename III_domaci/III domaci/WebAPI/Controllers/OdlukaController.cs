using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OdlukaController : ControllerBase
{
    [HttpGet("PreuzmiOdlukuZaCV/{cvId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetOdlukaZaCV(int cvId)
    {
        try
        {
            OdlukaBasic odluka = DTOManager.vratiOdlukuZaCV(cvId);

            if (odluka == null)
            {
                return BadRequest($"Odluka za CV prijavu sa ID={cvId} ne postoji.");
            }

            return Ok(odluka);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajOdluku/{cvId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddOdluka(int cvId, [FromBody] OdlukaBasic odluka)
    {
        try
        {
            DTOManager.dodajOdluku(odluka, cvId);

            return StatusCode(201, $"Uspešno doneta odluka za CV prijavu sa ID={cvId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOdluku")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOdluka([FromBody] OdlukaBasic odluka)
    {
        try
        {
            DTOManager.izmeniOdluku(odluka);

            return Ok($"Uspešno izmenjena odluka sa ID={odluka.OdlukaId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
