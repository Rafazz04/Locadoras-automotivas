using Locadoras.Models;

namespace LocadoraCrud.Services.Contracts;

public interface IVeiculoLogService
{
    void SalvarLogCriacaoVeiculo(Veiculo veiculo, Locadora locadora, Modelo modelo);
    void SalvarLogAtualizacaoVeiculo(Veiculo veiculo, Locadora locadora, Modelo modelo);
    void SalvarLogExclusaoVeiculo(Veiculo veiculo);
}
