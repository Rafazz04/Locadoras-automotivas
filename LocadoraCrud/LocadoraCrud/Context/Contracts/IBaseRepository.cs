using Locadoras.Context;
using System.Linq.Expressions;

namespace LocadoraCrud.Context.Contracts
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        void Add(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        bool SaveChanges();
        IQueryable<Entity> Where(Expression<Func<Entity, bool>> query, params Expression<Func<Entity, object>>[] includes);
        IQueryable<Entity> Skip(int page, int itens, Expression<Func<Entity, bool>> func = null);
        Entity FirstOrDefault(Expression<Func<Entity, bool>> query, params Expression<Func<Entity, object>>[] includes);
        IQueryable<Entity> All(params Expression<Func<Entity, object>>[] includes);
        bool Any(Expression<Func<Entity, bool>> condition = null);
        int Count(Expression<Func<Entity, bool>> query = null);
    }
}
