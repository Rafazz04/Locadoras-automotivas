using LocadoraCrud.Services.Contracts;
using Locadoras.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Locadoras.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocadoraController : ControllerBase
{
    private readonly ILocadoraService _locadoraService;
    public LocadoraController(ILocadoraService locadoraService)
    {
        _locadoraService = locadoraService;
    }

    [HttpGet]
    public ActionResult<LocadoraDto> GetLocadoras()
    {
        try
        {
            var locadoras = _locadoraService.RetornaLocadoras();

            if (locadoras != null)
                return Ok(locadoras);
            else
                return NotFound(); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpGet("{cnpj}")]
    public ActionResult<LocadoraDto> GetLocadora(string cnpj)
    {
        try
        {
            var locadora = _locadoraService.RetornaLocadora(cnpj);

            if (locadora != null)
                return Ok(locadora);
            else
                return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }

    }

    [HttpPost]

    public ActionResult<LocadoraDto> PostLocador(LocadoraDto locadoraDto)
    {
        try
        {
            var locadora = _locadoraService.CriaLocadora(locadoraDto);
            if (locadora != null)
                return StatusCode(201, locadora);
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpPut]
    public ActionResult<LocadoraDto> PutLocador(LocadoraDto locadoraDto, string cnpj)
    {
        try
        {
            var locadora = _locadoraService.AtualizaLocadora(locadoraDto, cnpj);
            if (locadora != null)
                return StatusCode(200, locadora);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpDelete]
    public ActionResult DeleteLocadora(string cnpj)
    {
        try
        {
            var locadora = _locadoraService.DeleteLocadora(cnpj);
            if (locadora)
                return StatusCode(200);
            return NotFound("Não foi encontrado esse CNPJ no sistema");

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
        
    }
}


