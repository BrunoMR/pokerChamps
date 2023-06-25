using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class Prizes
    {
        [BsonElement("Position")]
        public int Position { get; private set; }

        [BsonElement("Value")]
        public decimal Value { get; private set; }
    }
}