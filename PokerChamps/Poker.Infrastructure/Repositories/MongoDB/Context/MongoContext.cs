using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Poker.Infrastructure.Repositories.MongoDB.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;

        public IClientSessionHandle Session { get; set; }

        public MongoContext(IConfiguration configuration, IClientSessionHandle session)
        {
            Session = session;
            var mongoClient = new MongoClient(configuration["PKC_ConnectionStringMongoDb"]);
            _database = mongoClient.GetDatabase(configuration["PKC_DatabaseName"]);
        }

        public IMongoCollection<T> Collection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}