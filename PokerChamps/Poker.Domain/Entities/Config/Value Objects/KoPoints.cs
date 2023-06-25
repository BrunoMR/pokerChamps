using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class KoPoints
    {
        [BsonElement("Maker")]
        public int Maker { get; set; }

        [BsonElement("Receiver")]
        public int Receiver { get; set; }
    }
}