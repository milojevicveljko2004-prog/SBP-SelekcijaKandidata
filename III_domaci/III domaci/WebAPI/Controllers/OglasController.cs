using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.Entiteti.Enums;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OglasController : ControllerBase
{
    [HttpGet("PreuzmiSveOglase")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetOglasi()
    {
        try
        {
            List<OglasPregled> oglasi = DTOManager.vratiSveOglase();

            return Ok(oglasi);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("PreuzmiOglas/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetOglas(int id)
    {
        try
        {
            OglasBasic oglas = DTOManager.vratiOglas(id);

            if (oglas == null)
            {
                return BadRequest($"Oglas sa ID={id} ne postoji.");
            }

            return Ok(oglas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajOglasStalni")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddOglasStalni([FromBody] OglasBasic oglas)
    {
        try
        {
            oglas.VrstaOglasa = VrstaOglasa.STALNI;

            DTOManager.dodajOglas(oglas);

            return StatusCode(201, $"Uspešno dodat oglas: {oglas.NazivPozicije}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajOglasPraksa")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddOglasPraksa([FromBody] OglasPraksaBasic oglas)
    {
        try
        {
            oglas.VrstaOglasa = VrstaOglasa.PRAKSA;

            DTOManager.dodajOglas(oglas);

            return StatusCode(201, $"Uspešno dodat oglas za praksu: {oglas.NazivPozicije}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajOglasPrivremeni")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddOglasPrivremeni([FromBody] OglasPrivremeniBasic oglas)
    {
        try
        {
            if (oglas.DatumPocetka > oglas.DatumZavrsetka)
            {
                return BadRequest("Datum početka ne može biti posle datuma završetka.");
            }

            oglas.VrstaOglasa = VrstaOglasa.PRIVREMENI;

            DTOManager.dodajOglas(oglas);

            return StatusCode(201, $"Uspešno dodat privremeni oglas: {oglas.NazivPozicije}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DodajOglasSezonski")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult AddOglasSezonski([FromBody] OglasSezonskiBasic oglas)
    {
        try
        {
            oglas.VrstaOglasa = VrstaOglasa.SEZONSKI;

            DTOManager.dodajOglas(oglas);

            return StatusCode(201, $"Uspešno dodat sezonski oglas: {oglas.NazivPozicije}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasStalni/{staraVrsta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasStalni([FromBody] OglasBasic oglas, VrstaOglasa staraVrsta)
    {
        try
        {
            oglas.VrstaOglasa = VrstaOglasa.STALNI;

            OglasBasic izmenjeniOglas = DTOManager.izmeniOglas(oglas, staraVrsta);

            return Ok($"Uspešno izmenjen oglas sa ID={izmenjeniOglas.OglasId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasPraksa/{staraVrsta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasPraksa([FromBody] OglasPraksaBasic oglas, VrstaOglasa staraVrsta)
    {
        try
        {
            oglas.VrstaOglasa = VrstaOglasa.PRAKSA;

            OglasBasic izmenjeniOglas = DTOManager.izmeniOglas(oglas, staraVrsta);

            return Ok($"Uspešno izmenjen oglas za praksu sa ID={izmenjeniOglas.OglasId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasPrivremeni/{staraVrsta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasPrivremeni([FromBody] OglasPrivremeniBasic oglas, VrstaOglasa staraVrsta)
    {
        try
        {
            if (oglas.DatumPocetka > oglas.DatumZavrsetka)
            {
                return BadRequest("Datum početka ne može biti posle datuma završetka.");
            }

            oglas.VrstaOglasa = VrstaOglasa.PRIVREMENI;

            OglasBasic izmenjeniOglas = DTOManager.izmeniOglas(oglas, staraVrsta);

            return Ok($"Uspešno izmenjen privremeni oglas sa ID={izmenjeniOglas.OglasId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("IzmeniOglasSezonski/{staraVrsta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult ChangeOglasSezonski([FromBody] OglasSezonskiBasic oglas, VrstaOglasa staraVrsta)
    {
        try
        {
            oglas.VrstaOglasa = VrstaOglasa.SEZONSKI;

            OglasBasic izmenjeniOglas = DTOManager.izmeniOglas(oglas, staraVrsta);

            return Ok($"Uspešno izmenjen sezonski oglas sa ID={izmenjeniOglas.OglasId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("ObrisiOglas/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult DeleteOglas(int id)
    {
        try
        {
            DTOManager.obrisiOglas(id);

            return StatusCode(204, $"Uspešno obrisan oglas sa ID={id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
