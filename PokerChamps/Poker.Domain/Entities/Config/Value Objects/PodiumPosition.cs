using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class PodiumPosition
    {
        public PodiumPosition()
        {
        }
        
        public PodiumPosition(int position, int points)
        {
            Position = position;
            Points = points;
        }
        
        [BsonElement("Position")]
        public int Position { get; private set; }

        [BsonElement("Points")]
        public int Points { get; private set; }
    }
}