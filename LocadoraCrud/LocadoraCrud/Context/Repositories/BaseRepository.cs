using LocadoraCrud.Context.Contracts;
using Locadoras.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LocadoraCrud.Context.Repositories;

public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
{
    protected readonly LocadoraDbContext _context;
    protected BaseRepository(LocadoraDbContext context) => _context = context;

    public virtual void Add(Entity entity) => _context.Set<Entity>().Add(entity);
    public virtual void Update(Entity entity) => _context.Set<Entity>().Update(entity);
    public virtual void Delete(Entity entity) => _context.Set<Entity>().Remove(entity);
    public virtual bool SaveChanges() => _context.SaveChanges() > 0;
    public int Count(Expression<Func<Entity, bool>> query = null)
    {
        if (query != null)
            return _context.Set<Entity>().Where(query).Count();
        return _context.Set<Entity>().Count();
    }
    public IQueryable<Entity> Skip(int page, int itens, Expression<Func<Entity, bool>> func = null)
    {
        if (func != null)
            return _context.Set<Entity>().Where(func).Skip(page).Take(itens);
        else
            return _context.Set<Entity>().Skip(page).Take(itens);
    }
    public Entity FirstOrDefault(Expression<Func<Entity, bool>> func, params Expression<Func<Entity, object>>[] includes)
    {
        if (includes != null && includes.Length > 0)
        {
            IQueryable<Entity> _query = _context.Set<Entity>();
            foreach (var include in includes)
            {
                _query = _query.Include(include);
            }
            return _query.FirstOrDefault(func);
        }
        else
            return _context.Set<Entity>().FirstOrDefault(func);
    }
    public IQueryable<Entity> All(params Expression<Func<Entity, object>>[] includes)
    {
        if (includes != null && includes.Length > 0)
        {
            IQueryable<Entity> _query = _context.Set<Entity>();
            foreach (var include in includes)
            {
                _query = _query.Include(include);
            }
            return _query;
        }
        else
            return _context.Set<Entity>();
    }
    public bool Any(Expression<Func<Entity, bool>> condition = null)
    {
        return _context.Set<Entity>().Any(condition);
    }
    public IQueryable<Entity> Where(Expression<Func<Entity, bool>> func, params Expression<Func<Entity, object>>[] includes)
    {
        if (includes != null && includes.Length > 0)
        {
            IQueryable<Entity> _query = _context.Set<Entity>();
            foreach (var include in includes)
            {
                _query = _query.Include(include);
            }
            return _query.Where(func);
        }
        else
            return _context.Set<Entity>().Where(func);
    }
}
