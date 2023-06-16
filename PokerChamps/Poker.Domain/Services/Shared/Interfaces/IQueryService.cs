using System.Linq.Expressions;
using Poker.Domain.Entities.Base;

namespace Poker.Domain.Services.Config.Interfaces;

public interface IQueryService<TEntity> where TEntity : Entity 
{
    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    
    Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate);
}