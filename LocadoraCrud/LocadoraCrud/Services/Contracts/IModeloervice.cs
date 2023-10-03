using Locadoras.Dtos;
using Locadoras.Models;

namespace LocadoraCrud.Services.Contracts;

public interface IModeloService 
{
    ModeloDto RetornaModelo(string nomeModelo);
    List<ModeloDto> RetornaModelos();
    ModeloDto CriaModelo(ModeloDto modeloDto);
    ModeloDto AtualizaModelo(ModeloDto modeloDto, string nomeModelo);
    bool DeleteModelo(string nomeModelo);
    Modelo GetByIdModelo(int modeloId);
    Modelo GetByNomeModelo(string nomeModelo);
}
