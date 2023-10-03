using LocadoraCrud.Context.Contracts;
using Locadoras.Context;
using Locadoras.Models;

namespace LocadoraCrud.Context.Repositories;

public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
{
    public VeiculoRepository(LocadoraDbContext context) : base(context) {}
}
