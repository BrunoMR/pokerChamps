using MongoDB.Driver;
using Poker.Infrastructure.Repositories.MongoDB.Context;
using System.Linq.Expressions;
using Poker.Domain.Entities.Base;

namespace Poker.Infrastructure.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoCollection<T> _collection;

        public AbstractRepository(IMongoContext context)
        {
            _collection = context.Collection<T>();
        }

        public async Task InsertOneAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            await Task.Run(() =>
            {
                _collection.ReplaceOneAsync(Builders<T>.Filter.Eq(x => x.Id, entity.Id), entity);
            });
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _collection.FindAsync(predicate);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }
    }
}