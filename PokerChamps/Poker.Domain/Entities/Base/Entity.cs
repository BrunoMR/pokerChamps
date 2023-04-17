using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Base
{
    [Serializable]
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public virtual DateTime? UpdatedAt { get; set; }
    }
}