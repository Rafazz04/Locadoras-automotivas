using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Context.Repositories;
using LocadoraCrud.Services;
using LocadoraCrud.Services.Contracts;

namespace LocadoraCrud.IoC;

public static class LocadoraDependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ILocadoraRepository, LocadoraRepository>();
        services.AddTransient<IModeloRepository, ModeloRepository>();
        services.AddTransient<IMontadoraRepository, MontadoraRepository>();
        services.AddTransient<IVeiculoRepository, VeiculoRepository>();
        services.AddTransient<IVeiculoLogRepository, VeiculoLogRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ILocadoraService, LocadoraService>();
        services.AddTransient<IModeloService, ModeloService>();
        services.AddTransient<IMontadoraService, MontadoraService>();
        services.AddTransient<IVeiculoService, VeiculoService>();
        services.AddTransient<IVeiculoLogService, VeiculoLogService>();
        services.AddTransient<ILocadoraVeiculoService, LocadoraVeiculoService>();
        services.AddTransient<ILocadoraModeloService, LocadoraModeloService>();
    }
}
