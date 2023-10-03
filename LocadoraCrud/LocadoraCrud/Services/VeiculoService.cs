using AutoMapper;
using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Context.Repositories;
using LocadoraCrud.Services.Contracts;
using LocadoraCrud.Utils;
using Locadoras.Dtos;
using Locadoras.Models;
using System.Numerics;

namespace LocadoraCrud.Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IVeiculoLogService _veiculoLogService;
    private readonly ILocadoraService _locadoraService;
    private readonly IModeloService _modeloService;
    private readonly IMapper _mapper;

    public VeiculoService( IVeiculoRepository veiculoRepository,IVeiculoLogService veiculoLogService, ILocadoraService locadoraService, IModeloService modeloService,IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _veiculoLogService = veiculoLogService;
        _locadoraService = locadoraService;
        _modeloService = modeloService;
        _mapper = mapper;
    }

    public List<VeiculoDto> RetornaVeiculos()
    {
        var veiculo = _veiculoRepository.All().ToList();
        var veiculoDto = _mapper.Map<List<VeiculoDto>>(veiculo);
        return veiculoDto;
    }
    public VeiculoDto RetornaVeiculo(string placa, string chassi)
    {
        var veiculo = _veiculoRepository.Where(v => v.Placa == Util.LimpaFormatacaoPlaca(placa) && v.Chassi == Util.LimpaFormatacaoChassi(chassi)).FirstOrDefault();
        var veiculoDto = _mapper.Map<VeiculoDto>(veiculo);
        return veiculoDto;
    }
    public VeiculoDto CriaVeiculo(VeiculoDto veiculoDto)
    {
        try
        {
            veiculoDto.Placa = Util.LimpaFormatacaoPlaca(veiculoDto.Placa);
            veiculoDto.Chassi = Util.LimpaFormatacaoChassi(veiculoDto.Chassi);

            var locadora = _locadoraService.GetLocadoraByNome(veiculoDto.NomeLocadora);
            var modelo =_modeloService.GetByNomeModelo(veiculoDto.NomeModelo);

            if(locadora == null && modelo == null) {
                throw new Exception($"Locadora e Modelo com o nome {veiculoDto.NomeLocadora} e {veiculoDto.NomeModelo} não encontrados.");
            }

            var veiculo = _mapper.Map<Veiculo>(veiculoDto);
            veiculo.Locadora = locadora;
            veiculo.Modelo = modelo;

            if(!ExistePlaca(veiculo.Placa) && !ExisteChassi(veiculo.Chassi)){
                _veiculoRepository.Add(veiculo);
                if (_veiculoRepository.SaveChanges())
                {
                    _veiculoLogService.SalvarLogCriacaoVeiculo(veiculo, veiculo.Locadora, veiculo.Modelo);
                    return veiculoDto;
                }
                throw new Exception("Erro ao incluir Veiculo");
            }
            throw new Exception("Esse Veículo já existe no sistema");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
    public VeiculoDto AtualizaVeiculo(VeiculoDto veiculoDto, string placa, string chassi)
    {
        var veiculo = _veiculoRepository.FirstOrDefault(v => v.Placa == Util.LimpaFormatacaoPlaca(placa) && v.Chassi == Util.LimpaFormatacaoChassi(chassi));

        var locadora = _locadoraService.GetLocadoraByNome(veiculoDto.NomeLocadora);
        var modelo = _modeloService.GetByNomeModelo(veiculoDto.NomeModelo);

        if (locadora == null && modelo == null)
        {
            throw new Exception($"Locadora e Modelo com o nome {veiculoDto.NomeLocadora} e {veiculoDto.NomeModelo} não encontrados.");
        }
        if ( veiculo != null)
        {
            _veiculoRepository.Update(veiculo);
            if (_veiculoRepository.SaveChanges())
            {
                _veiculoLogService.SalvarLogAtualizacaoVeiculo(veiculo, veiculo.Locadora, veiculo.Modelo);
                return veiculoDto;
            }
            throw new Exception("Erro ao atualizar Veículo");
        }
        throw new Exception($"Esse veiculo com a placa: {placa} e chassi: {chassi} não foi localizado no sistema");

    }
    public bool DeleteVeiculo(string placa, string chassi)
    {
        var veiculo = _veiculoRepository.FirstOrDefault(v => v.Placa == Util.LimpaFormatacaoPlaca(placa) && v.Chassi == Util.LimpaFormatacaoChassi(chassi));
        if( veiculo != null )
        {
            _veiculoRepository.Delete(veiculo);
            if (_veiculoRepository.SaveChanges())
            {
                _veiculoLogService.SalvarLogExclusaoVeiculo(veiculo);
                return true;
            }
        }
        return false;
    }

    #region Métodos Adicionais
    private bool ExistePlaca(string placa)
    {
        var placaFormatada = Util.LimpaFormatacaoPlaca(placa);
        return _veiculoRepository.Where(v => v.Placa == placaFormatada).Any() ? true : false;
    }
    private bool ExisteChassi(string chassi)
    {
        var chassiFormatado = Util.LimpaFormatacaoChassi(chassi);
        return _veiculoRepository.Where(v => v.Placa == chassiFormatado).Any() ? true : false;
    }

    #endregion
}
