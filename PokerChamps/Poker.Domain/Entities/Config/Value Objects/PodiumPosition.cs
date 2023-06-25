using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class PodiumPosition
    {
        [BsonElement("Position")]
        public int Position { get; private set; }

        [BsonElement("Points")]
        public int Points { get; private set; }
    }
}