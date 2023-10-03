using Locadoras.Dtos;
using Locadoras.Models;

namespace LocadoraCrud.Services.Contracts;

public interface IVeiculoService
{
    VeiculoDto RetornaVeiculo(string placa, string chassi);
    List<VeiculoDto> RetornaVeiculos();
    VeiculoDto CriaVeiculo(VeiculoDto veiculoDto);
    VeiculoDto AtualizaVeiculo(VeiculoDto veiculoDto, string placa, string chassi);
    bool DeleteVeiculo(string placa, string chassi);
}
