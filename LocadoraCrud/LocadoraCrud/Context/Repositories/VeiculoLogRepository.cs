using LocadoraCrud.Context.Contracts;
using LocadoraCrud.Models;
using Locadoras.Context;

namespace LocadoraCrud.Context.Repositories
{
    public class VeiculoLogRepository : BaseRepository<VeiculoLog>, IVeiculoLogRepository
    {
        public VeiculoLogRepository(LocadoraDbContext context) : base(context) { }

    }
}
