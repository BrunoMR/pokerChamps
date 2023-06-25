using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Hand
    {
        public Hand(){}

        public Hand(string hand)
        {
            HandsEnum = hand;
            Quantity += 1;
        }
        
        [BsonElement("HandsEnum")]
        public string HandsEnum { get; private set; }

        [BsonElement("Quantity")]

        public int Quantity { get; private set; }

        public void AddQuantity()
        {
            Quantity += 1;
        }
    }
}