using AutoMapper;
using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Context.Repositories;
using LocadoraCrud.Services.Contracts;
using LocadoraCrud.Utils;
using Locadoras.Dtos;
using Locadoras.Models;

namespace LocadoraCrud.Services;

public class ModeloService : IModeloService
{
    private readonly IModeloRepository _modeloRepository;
    private readonly IMapper _mapper;

    public ModeloService(IModeloRepository modeloRepository, IMapper mapper)
    {
        _modeloRepository = modeloRepository;
        _mapper = mapper;
    }

    public List<ModeloDto> RetornaModelos()
    {
        var modelo = _modeloRepository.All().ToList();
        var modeloDto = _mapper.Map<List<ModeloDto>>(modelo);
        return modeloDto;
    }
    public ModeloDto RetornaModelo(string nomeModelo)
    {
        var modelo = _modeloRepository.Where(m => m.NomeModelo == Util.RemoverEspacosIgnoreCase(nomeModelo)).Single();
        var modeloDto = _mapper.Map<ModeloDto>(modelo);
        return modeloDto;
    }
    public ModeloDto CriaModelo(ModeloDto modeloDto)
    {
        try
        {
            var modelo = _mapper.Map<Modelo>(modeloDto);
            if (!_modeloRepository.Any(m => m.NomeModelo == modeloDto.NomeModelo))
            {
                _modeloRepository.Add(modelo);
                if (_modeloRepository.SaveChanges())
                    return modeloDto;
                throw new Exception("Erro ao incluir Modelo");
            }
            throw new Exception("Esse modelo já existe no sistema");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }
    public ModeloDto AtualizaModelo(ModeloDto modeloDto, string nomeModelo)
    {
        try
        {
            var modelo = _modeloRepository.FirstOrDefault(m => m.NomeModelo == Util.RemoverEspacosIgnoreCase(nomeModelo));
            if (modelo != null)
            {
                _modeloRepository.Update(modelo);
                if (_modeloRepository.SaveChanges())
                    return modeloDto;
                throw new Exception("Erro ao atualizar Modelo");

            }
            throw new Exception($"{nomeModelo} não pertence ao sistema ainda,");
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message} - {ex.StackTrace}");
        }
    }


    public bool DeleteModelo(string nomeModelo)
    {
        var modelo = _modeloRepository.FirstOrDefault(m => m.NomeModelo == Util.RemoverEspacosIgnoreCase(nomeModelo));
        if (modelo != null)
        {
            _modeloRepository.Delete(modelo);
            return _modeloRepository.SaveChanges();
        }
        return false;
    }

    public Modelo GetByIdModelo(int modeloId)
    {
        return _modeloRepository.FirstOrDefault(m => m.ModeloId == modeloId);
    }

    public Modelo GetByNomeModelo(string nomeModelo)
    {
        return _modeloRepository.FirstOrDefault(m => m.NomeModelo == Util.RemoverEspacosIgnoreCase(nomeModelo));
    }
}
