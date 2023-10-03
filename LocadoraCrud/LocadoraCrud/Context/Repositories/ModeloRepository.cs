using LocadoraCrud.Context.Contracts;
using Locadoras.Context;
using Locadoras.Models;

namespace LocadoraCrud.Context.Repositories;

public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
{
    public ModeloRepository(LocadoraDbContext context) : base(context) {}
}
