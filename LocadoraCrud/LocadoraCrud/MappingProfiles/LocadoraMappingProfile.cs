using AutoMapper;
using LocadoraCrud.Dtos;
using LocadoraCrud.Models;
using Locadoras.Dtos;
using Locadoras.Models;

namespace LocadoraCrud.MappingProfiles;

public class LocadoraMappingProfile : Profile
{
    public LocadoraMappingProfile()
    {
        CreateMap<Locadora, LocadoraDto>();
        CreateMap<LocadoraDto, Locadora>();

        CreateMap<Modelo, ModeloDto>();
        CreateMap<ModeloDto, Modelo>();

        CreateMap<Montadora, MontadoraDto>();
        CreateMap<MontadoraDto, Montadora>();

        CreateMap<Veiculo, VeiculoDto>()
            .ForMember(dest => dest.NomeLocadora, opt => opt.MapFrom(src => src.Locadora.RazaoSocial))
            .ForMember(dest => dest.NomeModelo, opt => opt.MapFrom(src => src.Modelo.NomeModelo))
            .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.DataCriacao.Date));

        CreateMap<VeiculoDto, Veiculo>();

        CreateMap<VeiculoLog, VeiculoLogDto>();
        CreateMap<VeiculoLogDto, VeiculoLog>();

        CreateMap<VeiculoLogDto, Veiculo>();

        CreateMap<Locadora, LocadoraVeiculoDto>();
        CreateMap<Locadora, LocadoraModeloDto>();

        CreateMap<Veiculo, LocadoraVeiculoDto>()
            .ForMember(dest => dest.NomeLocadora, opt => opt.MapFrom(src => src.Locadora.RazaoSocial))
            .ForMember(dest => dest.NomeModelo, opt => opt.MapFrom(src => src.Modelo.NomeModelo))
            .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCriacao));

        CreateMap<Veiculo, LocadoraModeloDto>()
            .ForMember(dest => dest.NomeLocadora, opt => opt.MapFrom(src => src.Locadora.RazaoSocial))
            .ForMember(dest => dest.NomeMontadora, opt => opt.MapFrom(src => src.Modelo.Montadora.NomeMontadora))
            .ForMember(dest => dest.NomeModelo, opt => opt.MapFrom(src => src.Modelo.NomeModelo))
            .ForMember(dest => dest.QuantidadeVeiculos, opt => opt.Ignore()); 
    }

}
