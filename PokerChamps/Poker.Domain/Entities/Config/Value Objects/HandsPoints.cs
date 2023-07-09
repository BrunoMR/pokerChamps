using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class HandsPoints
    {
        public HandsPoints()
        {
            
        }
        
        public HandsPoints(HandsEnum type, int value)
        {
            Type = type;
            Value = value;
        }
        
        [BsonElement("Type")]
        public HandsEnum Type { get; private set; }

        [BsonElement("Value")]
        public int Value { get; private set; }
    }
}