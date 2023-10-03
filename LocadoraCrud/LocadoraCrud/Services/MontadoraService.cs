using AutoMapper;
using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Services.Contracts;
using LocadoraCrud.Utils;
using Locadoras.Dtos;
using Locadoras.Models;

namespace LocadoraCrud.Services;

public class MontadoraService : IMontadoraService
{
    private readonly IMontadoraRepository _montadoraRepository;
    private readonly IMapper _mapper;

    public MontadoraService(IMontadoraRepository montadoraRepository, IMapper mapper)
    {
        _montadoraRepository = montadoraRepository;
        _mapper = mapper;
    }
    public List<MontadoraDto> RetornaMontadoras()
    {
        var montadora = _montadoraRepository.All().ToList();
        var montadoraDto = _mapper.Map<List<MontadoraDto>>(montadora);
        return montadoraDto;
    }

    public MontadoraDto RetornaMontadora(string nomeMontadora)
    {
        var montadora = _montadoraRepository.Where(m => m.NomeMontadora == Util.RemoverEspacosIgnoreCase(nomeMontadora)).Single();
        var montadoraDto = _mapper.Map<MontadoraDto>(montadora);
        return montadoraDto;
    }

    public MontadoraDto CriaMontadora(MontadoraDto montadoraDto)
    {
        try
        {
            var montadora = _mapper.Map<Montadora>(montadoraDto);
            if(!_montadoraRepository.Any(m => m.NomeMontadora == montadoraDto.NomeMontadora))
            {
                _montadoraRepository.Add(montadora);
                if(_montadoraRepository.SaveChanges())
                    return montadoraDto;
                throw new Exception("Erro ao incluir Montadora");
            }
            throw new Exception("Essa montadora já existe no sistema");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
    public MontadoraDto AtualizaMontadora(MontadoraDto montadoraDto, string nomeMontadora)
    {
        try
        {
            var montadora = _montadoraRepository.FirstOrDefault(m => m.NomeMontadora == Util.RemoverEspacosIgnoreCase(nomeMontadora));
            if (montadora != null)
            {
                _montadoraRepository.Update(montadora);
                if (_montadoraRepository.SaveChanges())
                    return montadoraDto;
                throw new Exception("Erro ao atualizar Montadora");

            }
            throw new Exception($"{nomeMontadora} não pertence ao sistema ainda,");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }

    public bool DeleteMontadora(string nomeMontadora)
    {
        var montadora = _montadoraRepository.FirstOrDefault(m => m.NomeMontadora == Util.RemoverEspacosIgnoreCase(nomeMontadora));
        if (montadora != null)
        {
            _montadoraRepository.Delete(montadora);
            return _montadoraRepository.SaveChanges();
        }
        return false;

    }


}
