using LocadoraCrud.Services.Contracts;
using Locadoras.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Locadoras.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MontadoraController : ControllerBase
{
    private readonly IMontadoraService _montadoraService;

    public MontadoraController(IMontadoraService montadoraService)
    {
        _montadoraService = montadoraService;
    }

    [HttpGet]
    public ActionResult<MontadoraDto> GetMontadoras()
    {
        try
        {
            var montadoras = _montadoraService.RetornaMontadoras();
            if (montadoras != null)
                return Ok(montadoras);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpGet("{nomeMontadora}")]
    public ActionResult<MontadoraDto> GetMontadora(string nomeMontadora)
    {
        try
        {
            var montadora = _montadoraService.RetornaMontadora(nomeMontadora);
            if (montadora != null)
                return Ok(montadora);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpPost]
    public ActionResult<MontadoraDto> PostMontadora(MontadoraDto montadoraDto) 
    {
        try
        {
            var montadora = _montadoraService.CriaMontadora(montadoraDto);
            if (montadora != null)
                return StatusCode(201, montadora);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpPut]
    public ActionResult<MontadoraDto> PutMontadora(MontadoraDto montadoraDto, string nomeMontadora)
    {
        try
        {
            var montadora = _montadoraService.AtualizaMontadora(montadoraDto, nomeMontadora);
            if(montadora != null)
                return StatusCode(200, montadora);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpDelete]
    public ActionResult DeleteMontadora(string nomeMontadora)
    {
        try
        {
            var montadora = _montadoraService.DeleteMontadora(nomeMontadora);
            if(montadora)
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
    
}
