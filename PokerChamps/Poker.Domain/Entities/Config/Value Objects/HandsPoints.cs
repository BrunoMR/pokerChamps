using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class HandsPoints
    {
        [BsonElement("Type")]
        public HandsEnum Type { get; private set; }

        [BsonElement("Value")]
        public int Value { get; private set; }
    }
}