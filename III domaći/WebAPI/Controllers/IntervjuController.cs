using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class IntervjuController : ControllerBase
{
    [HttpGet("PreuzmiIntervjueCVPrijave/{cvId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetIntervjueCVPrijave(int cvId)
    {
        try
        {
            List<IntervjuPregled> intervjui = DTOManager.vratiIntervjueCVPrijave(cvId);

            return Ok(intervjui);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("PreuzmiIntervju/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetIntervju(int id)
    {
        try
        {
            IntervjuBasic intervju = DTOManager.vratiIntervju(id);

            return Ok(intervju);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajIntervju/{cvId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddIntervju(int cvId, [FromBody] IntervjuBasic intervju)
    {
        try
        {
            DTOManager.dodajIntervju(intervju, cvId);

            return StatusCode(201, $"Uspešno dodat intervju za CV prijavu sa ID={cvId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniIntervju")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeIntervju([FromBody] IntervjuBasic intervju)
    {
        try
        {
            DTOManager.izmeniIntervju(intervju);

            return Ok($"Uspešno izmenjen intervju sa ID={intervju.IntervjuId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("ObrisiIntervju/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult DeleteIntervju(int id)
    {
        try
        {
            DTOManager.obrisiIntervju(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
