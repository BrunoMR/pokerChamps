namespace Poker.Domain.Entities.Config
{
    public class Points
    {
        public decimal BuyIn { get; set; }

        public decimal Rebuy { get; set; }

        public int PodiumPosition { get; set; }

        public KoPoints Ko { get; set; }

        public IEnumerable<HandsPoints> HandsPoints { get; set; }
    }
}