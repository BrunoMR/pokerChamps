using MongoDB.Bson.Serialization.Attributes;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class Points
    {
        [BsonElement("Rebuy")]
        public double Rebuy { get; private set; }

        [BsonElement("PodiumPosition")]
        public List<PodiumPosition> PodiumPosition { get; private set; }

        [BsonElement("Ko")]
        public KoPoints Ko { get; private set; }

        [BsonElement("HandsPoints")]
        public List<HandsPoints> HandsPoints { get; private set; }

        public Points(double rebuy)
        {
            Rebuy = rebuy;
        }

        public void SetPodiumPostions(PodiumPosition podiumPosition)
        {
            if (PodiumPosition == null)
                PodiumPosition = new List<PodiumPosition>();
            PodiumPosition.Add(podiumPosition);
        }

        public void SetDansPoints(HandsPoints handsPoints)
        {
            if(HandsPoints == null)
                HandsPoints = new List<HandsPoints>();
            HandsPoints.Add(handsPoints);
        }

        public void SetKoPoints(KoPoints koPoints)
        {
            Ko = koPoints;
        }
    }
}