using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Models;
using LocadoraCrud.Services.Contracts;
using LocadoraCrud.Utils;
using Locadoras.Models;
using System.Runtime.InteropServices;

namespace LocadoraCrud.Services;

public class VeiculoLogService : IVeiculoLogService
{
    private readonly IVeiculoLogRepository _veiculoLogRepository;
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoLogService(IVeiculoLogRepository veiculoLogRepository, IVeiculoRepository veiculoRepository)
    {
        _veiculoLogRepository = veiculoLogRepository;
        _veiculoRepository = veiculoRepository;
    }

    public void SalvarLogCriacaoVeiculo(Veiculo veiculo, Locadora locadora, Modelo modelo)
    {
        var ultimoLog = _veiculoLogRepository.Where(vl => vl.VeiculoId == veiculo.VeiculoId && vl.DataFim == null).OrderByDescending(vl => vl.DataInicio).FirstOrDefault();

        var log = new VeiculoLog
        {
            VeiculoId = veiculo.VeiculoId,
            NomeLocadora = locadora.RazaoSocial,
            NomeModelo = modelo.NomeModelo,
            DataInicio = DateTime.Now,
            DataFim = null
        };

        if (ultimoLog != null) 
        {
            SalvarLogAtualizacaoVeiculo(veiculo, locadora, modelo);
        }

        _veiculoLogRepository.Add(log);
        _veiculoLogRepository.SaveChanges();
    }
    public void SalvarLogAtualizacaoVeiculo(Veiculo veiculo, Locadora locadora, Modelo modelo)
    {
        var ultimoLog = _veiculoLogRepository.Where(vl => vl.VeiculoId == veiculo.VeiculoId && vl.DataFim == null).OrderByDescending(vl => vl.DataInicio).FirstOrDefault();

        if (ultimoLog != null)
        {
            ultimoLog.DataFim = DateTime.Now;
            _veiculoLogRepository.Update(ultimoLog);
        }

        var novoLog = new VeiculoLog
        {
            VeiculoId = veiculo.VeiculoId,
            NomeLocadora = locadora.RazaoSocial,
            NomeModelo = modelo.NomeModelo,
            DataInicio = DateTime.Now,
            DataFim = null 
        };

        _veiculoLogRepository.Add(novoLog);
        _veiculoLogRepository.SaveChanges();
    }


    public void SalvarLogExclusaoVeiculo(Veiculo veiculo)
    {
        var ultimoLog = _veiculoLogRepository
            .Where(vl => vl.VeiculoId == veiculo.VeiculoId && vl.DataFim == null)
            .OrderByDescending(vl => vl.DataInicio)
            .FirstOrDefault();

        if (ultimoLog != null)
        {
            ultimoLog.DataFim = DateTime.Now;
            _veiculoLogRepository.Update(ultimoLog);
            _veiculoLogRepository.SaveChanges(); 
        }
    }
}
