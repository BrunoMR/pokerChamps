using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class Prices
    {
        [BsonElement("CashBox")] 
        public decimal CashBox { get; private set; }

        [BsonElement("BuyIn")] 
        public decimal BuyIn { get; private set; }

        [BsonElement("Rebuy")] 
        public decimal Rebuy { get; private set; }
    }
}