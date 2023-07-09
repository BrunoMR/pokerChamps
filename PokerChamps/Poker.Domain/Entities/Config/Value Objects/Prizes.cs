using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class Prizes
    {
        public Prizes()
        {
        }

        public Prizes(int position, decimal value)
        {
            Position = position;
            Value = value;
        }
        
        [BsonElement("Position")] 
        public int Position { get; private set; }

        [BsonElement("Value")] 
        public decimal Value { get; private set; }
    }
}