using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Dtos;
using LocadoraCrud.Services.Contracts;
using Locadoras.Context;
using Microsoft.EntityFrameworkCore;

namespace LocadoraCrud.Services;

public class LocadoraVeiculoService : ILocadoraVeiculoService
{
    private readonly LocadoraDbContext _context;

    public LocadoraVeiculoService(LocadoraDbContext context)
    {
        _context = context;
    }

    //public List<LocadoraVeiculoDto> ObtemRelatorioLocadorasVeiculos(int? locadoraId, DateTime? dataCriacaoVeiculo, int? modeloId)
    //{
    //    var consulta = _context.Veiculos.Include(v => v.Locadora).Include(v => v.Modelo).AsQueryable();

    //    if (locadoraId.HasValue)
    //        consulta = consulta.Where(v => v.LocadoraId == locadoraId);
    //    if (dataCriacaoVeiculo.HasValue)
    //        consulta = consulta.Where(v => v.DataCriacao.Date == dataCriacaoVeiculo.Value.Date);
    //    if(modeloId.HasValue)
    //        consulta = consulta.Where(v => v.ModeloId == modeloId);
    //    return consulta.ToList();
    //}
}
