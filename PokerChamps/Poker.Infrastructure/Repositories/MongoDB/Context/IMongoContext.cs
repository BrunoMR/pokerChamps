using MongoDB.Driver;

namespace Poker.Infrastructure.Repositories.MongoDB.Context
{
    public interface IMongoContext
    {
        IMongoCollection<T> Collection<T>();

        IMongoCollection<T> Collection<T>(string collectionName);
    }
}