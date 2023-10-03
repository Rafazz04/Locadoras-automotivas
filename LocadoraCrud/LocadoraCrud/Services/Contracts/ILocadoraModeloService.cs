
using LocadoraCrud.Dtos;

namespace LocadoraCrud.Services.Contracts;

public interface ILocadoraModeloService
{
    List<LocadoraModeloDto> ObtemRelatorioLocadorasModelos();
}