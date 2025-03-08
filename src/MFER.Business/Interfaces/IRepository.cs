using System.Linq.Expressions;
using MFER.Business.Models;

namespace MFER.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Adicionar(TEntity obj);
    Task<TEntity?> ObterPorId(Guid id);
    Task<List<TEntity>> ObterTodos();
    Task Atualizar(TEntity obj);
    Task Remover(Guid id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}