using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Entities.Base;
using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Domain.Entities.Config
{
    public class Configs : Entity
    {
        [BsonElement("Points")]
        public Points Points { get; private set; }

        [BsonElement("Prices")]
        public Prices Prices { get; private set; }

        [BsonElement("TurnBlinds")]
        public List<TurnBlinds> TurnBlinds { get; private set; }
        
        [BsonElement("Prizes")]
        public List<Prizes> Prizes { get; private set; }

        public void SetId(string id)
        {
            Id = id;
        }

        public void SetPoints(Points points)
        {
            Points = points;
        }

        public void SetPrices(Prices prices)
        {
            Prices = prices;
        }

        public void SetTurnBlinds(TurnBlinds turnBlinds)
        {
            if (turnBlinds != null)
                TurnBlinds = new List<TurnBlinds>();

            TurnBlinds.Add(turnBlinds);
        }
    }
}