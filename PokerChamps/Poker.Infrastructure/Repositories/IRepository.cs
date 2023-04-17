using System.Linq.Expressions;
using Poker.Domain.Entities.Base;

namespace Poker.Infrastructure.Repositories
{
    public interface IRepository <T> where T : Entity
    {
        Task InsertOneAsync(T entity);

        Task UpdateAsync(T entity);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}