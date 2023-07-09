using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Entities.Player;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Ko
    {
        public Ko(){}

        public Ko(IEnumerable<Players> makers, IEnumerable<Players> receivers)
        {
            Makers = makers;
            Receivers = receivers;
        }


        [BsonElement("Makers")]
        public IEnumerable<Players> Makers { get; private set; }

        [BsonElement("PointsByMaker")]
        public double PointsByMaker { get; private set; }

        [BsonElement("Receivers")]
        public IEnumerable<Players> Receivers { get; private set; }

        public void SetPointsByMaker(double points)
        {
            PointsByMaker = points / Makers.Count();
        }
    }
}