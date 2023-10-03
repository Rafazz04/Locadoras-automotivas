using LocadoraCrud.Services.Contracts;
using Locadoras.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Locadoras.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoService _veiculoService;

    public VeiculoController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    [HttpGet]
    public ActionResult<VeiculoDto> GetVeiculos()
    {
        try
        {
            var veiculos = _veiculoService.RetornaVeiculos();
            if (veiculos != null)
                return Ok(veiculos);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpGet("{placa}/{chassi}")]
    public ActionResult<VeiculoDto> GetVeiculo(string placa, string chassi)
    {
        try
        {
            var veiculo = _veiculoService.RetornaVeiculo(placa, chassi);
            if (veiculo != null)
                return Ok(veiculo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpPost]
    public ActionResult<VeiculoDto> PostVeiculo(VeiculoDto veiculoDto)
    {
        try
        {
            var veiculo = _veiculoService.CriaVeiculo(veiculoDto);
            if (veiculo != null) 
                return StatusCode(200, veiculo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpPut]
    public ActionResult<VeiculoDto> PutVeiculo(VeiculoDto veiculoDto, string placa, string chassi) 
    {
        try
        {
            var veiculo = _veiculoService.AtualizaVeiculo(veiculoDto, placa, chassi); 
            if(veiculo != null)
                return Ok(veiculo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    [HttpDelete]
    public ActionResult DeletaVeiculo(string placa, string chassi)
    {
        try
        {
            var veiculo = _veiculoService.DeleteVeiculo(placa, chassi);
            if(veiculo)
                return Ok(veiculo);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
}
