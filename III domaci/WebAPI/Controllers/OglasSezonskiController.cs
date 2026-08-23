using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OglasSezonskiController : ControllerBase
{
    [HttpGet("PreuzmiOglasSezonski/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetOglasSezonski(int id)
    {
        try
        {
            OglasSezonskiBasic oglas = DTOManager.vratiOglasSezonski(id);

            if (oglas == null)
            {
                return BadRequest($"Podaci o sezonskom oglasu sa ID={id} ne postoje.");
            }

            return Ok(oglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasSezonski")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasSezonski([FromBody] OglasSezonskiBasic oglas)
    {
        try
        {
            OglasSezonskiBasic izmenjeniOglas = DTOManager.izmeniOglasSezonski(oglas);

            return Ok(izmenjeniOglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
