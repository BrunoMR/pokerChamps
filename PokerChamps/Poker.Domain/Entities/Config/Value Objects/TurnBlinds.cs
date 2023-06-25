using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class TurnBlinds
    {
        [BsonElement("Time")]
        // in seconds
        public int Time { get; private set; }

        [BsonElement("BlindValue")]
        public decimal BlindValue { get; private set; }

        [BsonElement("BigBlindValue")]
        public decimal BigBlindValue { get; private set; }

        public TurnBlinds(int time, decimal blindValue, decimal bigBlindValue)
        {
            Time = time;
            BlindValue = blindValue;
            BigBlindValue = bigBlindValue;
        }
    }
}