using Locadoras.Dtos;
using Locadoras.Models;

namespace LocadoraCrud.Services.Contracts;

public interface IMontadoraService 
{
    MontadoraDto RetornaMontadora(string nomeMontadora);
    List<MontadoraDto> RetornaMontadoras();
    MontadoraDto CriaMontadora(MontadoraDto montadoraDto);
    MontadoraDto AtualizaMontadora(MontadoraDto montadoraDto, string nomeMontadora);
    bool DeleteMontadora(string nomeMontadora);

}

