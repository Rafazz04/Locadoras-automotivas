using LocadoraCrud.Context.Contracts;
using Locadoras.Context;
using Locadoras.Models;

namespace LocadoraCrud.Context.Repositories;

public class MontadoraRepository : BaseRepository<Montadora>, IMontadoraRepository
{
    public MontadoraRepository(LocadoraDbContext context) : base(context) {}
}
