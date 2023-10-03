using LocadoraCrud.Dtos;
using LocadoraCrud.Services;
using LocadoraCrud.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraCrud.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly ILocadoraVeiculoService _locadoraVeiculoService;
    private readonly ILocadoraModeloService _locadoraModeloService;

    public RelatoriosController(ILocadoraVeiculoService locadoraVeiculoService, ILocadoraModeloService locadoraModeloService)
    {
        _locadoraVeiculoService = locadoraVeiculoService;
        _locadoraModeloService = locadoraModeloService;
    }

    [HttpGet]
    public ActionResult<LocadoraModeloDto> GetLocadoraModelo()
    {
        try
        {
            var relatorio = _locadoraModeloService.ObtemRelatorioLocadorasModelos();
            if (relatorio != null)
                return Ok(relatorio);
            return BadRequest();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
}
