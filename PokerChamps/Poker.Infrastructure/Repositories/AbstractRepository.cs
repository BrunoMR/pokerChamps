using MongoDB.Driver;
using Poker.Infrastructure.Repositories.MongoDB.Context;
using System.Linq.Expressions;
using Poker.Domain.Adapters.Repositories;
using Poker.Domain.Entities.Base;

namespace Poker.Infrastructure.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IClientSessionHandle _session;

        public AbstractRepository(IMongoContext context, IClientSessionHandle session)
        {
            _collection = context.Collection<T>();
            _session = session;
        }

        public async Task InsertOneAsync(T entity)
        {
            await _collection.InsertOneAsync(_session, entity);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            await Task.Run(() =>
            {
                _collection.ReplaceOneAsync(_session, Builders<T>.Filter.Eq(x => x.Id, entity.Id), entity);
            });
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _collection.FindAsync(_session, predicate);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(_session, predicate).ToListAsync();
        }
    }
}