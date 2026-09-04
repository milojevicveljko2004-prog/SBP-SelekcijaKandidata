using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CVController : ControllerBase
{
    [HttpGet("PreuzmiSveCVPrijave")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetSveCVPrijave()
    {
        (bool isError, var prijave, ErrorMessage? error) = DTOManager.vratiSveCVPrijave();

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return Ok(prijave);
    }

    [HttpGet("PreuzmiCVPrijaveOglasa/{oglasId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetCVPrijaveOglasa(int oglasId)
    {
        try
        {
            List<CVPregled> prijave = DTOManager.vratiCVPrijaveOglasa(oglasId);

            return Ok(prijave);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("PreuzmiCV/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetCV(int id)
    {
        try
        {
            CVBasic cv = DTOManager.vratiCV(id);

            return Ok(cv);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajCV/{oglasId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddCV(int oglasId, [FromBody] CVBasic cv)
    {
        try
        {
            DTOManager.dodajCV(cv, oglasId);

            return StatusCode(201, $"Uspešno dodata CV prijava: {cv.Ime} {cv.Prezime}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniCV")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeCV([FromBody] CVBasic cv)
    {
        try
        {
            DTOManager.izmeniCV(cv);

            return Ok($"Uspešno izmenjena CV prijava sa ID={cv.CvId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("ObrisiCV/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult DeleteCV(int id)
    {
        try
        {
            DTOManager.obrisiCV(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("ObrisiCVPrijavu/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult DeleteCVPrijavu(int id)
    {
        (bool isError, var obrisano, ErrorMessage? error) = DTOManager.ObrisiCVPrijavu(id);

        if (isError)
        {
            return StatusCode(error?.StatusCode ?? 400, error?.Message);
        }

        return NoContent();
    }
}
