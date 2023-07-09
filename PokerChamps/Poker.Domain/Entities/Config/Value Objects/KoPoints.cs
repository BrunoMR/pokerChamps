using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class KoPoints
    {
        public KoPoints()
        {
            
        }
        
        public KoPoints(int maker, int receiver)
        {
            Maker = maker;
            Receiver = receiver;
        }
        
        [BsonElement("Maker")]
        public int Maker { get; set; }

        [BsonElement("Receiver")]
        public int Receiver { get; set; }
    }
}