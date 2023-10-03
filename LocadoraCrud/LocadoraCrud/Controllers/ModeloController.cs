using LocadoraCrud.Services.Contracts;
using Locadoras.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Locadoras.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModeloController : ControllerBase
{
    private readonly IModeloService _modeloService;
    public ModeloController(IModeloService modeloService)
    {
        _modeloService = modeloService;
    }

    [HttpGet]
    public ActionResult<ModeloDto> GetModelos()
    {
        try
        {
            var modelos = _modeloService.RetornaModelos();
            if(modelos != null)
                return Ok(modelos);
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpGet("{nomeModelo}")]
    public ActionResult<ModeloDto> GetModelo(string nomeModelo) 
    {
        try
        {
            var modelo = _modeloService.RetornaModelo(nomeModelo);
            if(modelo != null) 
                return Ok(modelo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpPost]
    public ActionResult<ModeloDto> PostModelo (ModeloDto modeloDto)
    {
        try
        {
            var modelo = _modeloService.CriaModelo(modeloDto);
            if (modelo != null)
                return StatusCode(201, modelo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpPut]
    public ActionResult<ModeloDto> PutModelo(ModeloDto modeloDto, string nomeModelo)
    {
        try
        {
            var modelo = _modeloService.AtualizaModelo(modeloDto, nomeModelo);
            if(modelo != null)
                return Ok(modelo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpDelete]
    public ActionResult<ModeloDto> DeleteModelo(string nomeModelo)
    {
        try
        {
            var veiculo = _modeloService.DeleteModelo(nomeModelo);
            if(veiculo)
                return Ok(veiculo);
            return NotFound("Não foi encontrado esse veículo no sistema");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message} - {ex.StackTrace}");
        }
    }
}
