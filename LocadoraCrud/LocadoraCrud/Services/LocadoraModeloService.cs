using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Dtos;
using LocadoraCrud.Services.Contracts;
using Locadoras.Context;

namespace LocadoraCrud.Services;

public class LocadoraModeloService : ILocadoraModeloService
{
    private readonly LocadoraDbContext _context;

    public LocadoraModeloService(LocadoraDbContext locadoraDbContext)
    {
        _context = locadoraDbContext;
    }
    public List<LocadoraModeloDto> ObtemRelatorioLocadorasModelos()
    {
        var relatorio = _context.Veiculos.GroupBy(v => new { v.Locadora.NomeFantasia, v.Modelo.Montadora.NomeMontadora, v.Modelo.NomeModelo }).Select(g => new LocadoraModeloDto
        {
            NomeLocadora = g.Key.NomeFantasia,
            NomeMontadora = g.Key.NomeMontadora,
            NomeModelo = g.Key.NomeModelo,
            QuantidadeVeiculos = g.Count()
        }).ToList();
        return relatorio;
    }
}
