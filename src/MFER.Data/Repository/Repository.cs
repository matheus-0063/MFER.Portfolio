using System.Linq.Expressions;
using MFER.Business.Interfaces;
using MFER.Business.Models;
using MFER.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MFER.Data.Repository;

public class Repository<TEntity>(MferDbContext _mferDbContext, DbSet<TEntity> _entitySet) 
    : IRepository<TEntity> where TEntity : Entity, new()
{
    public virtual async Task<TEntity?> ObterPorId(Guid id)
    {
        return await _entitySet.FindAsync(id);
    }

    public virtual Task<List<TEntity>> ObterTodos()
    {
        return _entitySet.ToListAsync();
    }
    
    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entitySet.AsNoTracking().Where(predicate).ToListAsync();
    }
    
    public virtual async Task Adicionar(TEntity obj)
    {
        _entitySet.Add(obj);
        await SaveChanges();
    }
    
    public virtual Task Atualizar(TEntity obj)
    {
        _entitySet.Update(obj);
        return SaveChanges();
    }

    public virtual Task Remover(Guid id)
    {
        _mferDbContext.Remove(new TEntity { Id = id });
        return SaveChanges();
    }
    
    public Task<int> SaveChanges()
    {
        return _mferDbContext.SaveChangesAsync();
    }
        
    public void Dispose()
    {
        _mferDbContext?.Dispose();
    }
}
