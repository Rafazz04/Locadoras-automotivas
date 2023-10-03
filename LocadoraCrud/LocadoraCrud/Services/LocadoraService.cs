using AutoMapper;
using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Services.Contracts;
using LocadoraCrud.Utils;
using Locadoras.Dtos;
using Locadoras.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraCrud.Services;

public class LocadoraService : ILocadoraService
{
    private readonly ILocadoraRepository _locadoraRepository;
    private readonly IMapper _mapper;
    public LocadoraService(ILocadoraRepository locadoraRepository, IMapper mapper)
    {
        _locadoraRepository = locadoraRepository;
        _mapper = mapper;
    }

    public List<LocadoraDto> RetornaLocadoras()
    {
        var locadoras = _locadoraRepository.All().ToList();
        var locadoraDto = _mapper.Map<List<LocadoraDto>>(locadoras);
        return locadoraDto;
    }
    public LocadoraDto RetornaLocadora(string cnpj)
    {
        var cnpjFormatado = Util.LimpaFormatacaoCnpj(cnpj);
        var locadora = _locadoraRepository.Where(l => l.CNPJ == cnpjFormatado).Single();
        var locadoraDto = _mapper.Map<LocadoraDto>(locadora);
        return locadoraDto;
    }
    public LocadoraDto CriaLocadora(LocadoraDto locadoraDto)
    {
        try
        {
            locadoraDto.CNPJ = Util.LimpaFormatacaoCnpj(locadoraDto.CNPJ);
            var locadora = _mapper.Map<Locadora>(locadoraDto);

            if (!ExisteCnpj(locadora.CNPJ))
            {
                _locadoraRepository.Add(locadora);
                if (_locadoraRepository.SaveChanges())
                    return locadoraDto;
                throw new Exception("Erro ao salvar no sistema");
            }
            else
                throw new Exception("CNPJ já cadastrado no sistema");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
    public LocadoraDto AtualizaLocadora(LocadoraDto locadoraDto, string cnpj)
    {
        try
        {
            var cnpjFormatado = Util.LimpaFormatacaoCnpj(cnpj);
            locadoraDto.CNPJ = cnpjFormatado;

            var locadora = _locadoraRepository.FirstOrDefault(l => l.CNPJ == cnpjFormatado);
            var existeLocadora = _locadoraRepository.FirstOrDefault(l => l.CNPJ == cnpjFormatado && l.LocadoraId != locadora.LocadoraId);


            if (locadora != null && existeLocadora == null)
            {
                locadora = _mapper.Map<Locadora>(locadoraDto);
                _locadoraRepository.Update(locadora);
                if (_locadoraRepository.SaveChanges())
                    return locadoraDto;
                throw new Exception("Erro ao Atualizar no sistema");
            }
            else
                throw new Exception("CNPJ não encontrado no sistema ou já pertence a outra locadora");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }

    }
    public bool DeleteLocadora(string cnpj)
    {
        var cnpjFormatado = Util.LimpaFormatacaoCnpj(cnpj);
        var locadora = _locadoraRepository.FirstOrDefault(l => l.CNPJ == cnpj);

        if(locadora != null)
        {
            _locadoraRepository.Delete(locadora);
            return _locadoraRepository.SaveChanges();
        }
        return false;
    }

    #region Métodos Adicionais
    private bool ExisteCnpj(string cnpj)
    {
        var cnpjFormatado = Util.LimpaFormatacaoCnpj(cnpj);
        return _locadoraRepository.Where(c => c.CNPJ == cnpjFormatado).Any() ? true : false;
    }

    public Locadora GetByIdLocadora(int locadoraid)
    {
        return _locadoraRepository.FirstOrDefault(l => l.LocadoraId == locadoraid);
    }
    public Locadora GetLocadoraByNome(string razaoSocial)
    {
        return _locadoraRepository.FirstOrDefault(l => l.RazaoSocial == razaoSocial);
    }
    #endregion
}
