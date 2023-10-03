using Locadoras.Dtos;
using Locadoras.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraCrud.Services.Contracts;

public interface ILocadoraService
{
    LocadoraDto RetornaLocadora(string cnpj);
    List<LocadoraDto> RetornaLocadoras();
    LocadoraDto CriaLocadora(LocadoraDto locadoraDto);
    LocadoraDto AtualizaLocadora(LocadoraDto locadoraDto, string cnpj);
    bool DeleteLocadora(string cnpj);
    Locadora GetByIdLocadora(int locadoraid);
    Locadora GetLocadoraByNome(string razaoSocial);
}
