namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class Points
    {
        public decimal Rebuy { get; set; }

        public List<PodiumPosition> PodiumPosition { get; set; }

        public KoPoints Ko { get; set; }

        public List<HandsPoints> HandsPoints { get; set; }

        public Points(decimal rebuy)
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