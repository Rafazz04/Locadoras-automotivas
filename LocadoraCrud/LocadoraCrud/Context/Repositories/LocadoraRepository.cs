using LocadoraCrud.Context.Contracts;
using Locadoras.Context;
using Locadoras.Models;

namespace LocadoraCrud.Context.Repositories;

public class LocadoraRepository : BaseRepository<Locadora>, ILocadoraRepository
{
    public LocadoraRepository(LocadoraDbContext context) : base(context) {}
}
