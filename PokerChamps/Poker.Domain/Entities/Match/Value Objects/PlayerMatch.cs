using Poker.Domain.Entities.Player;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class PlayerMatch
    {
        public Players Player { get; set; }

        public double KoQuantity { get; set; }

        public int RebuyQuantity { get; set; }

        public IEnumerable<Hand> Hands { get; set; }

        public int Points { get; set; }

        public int Position { get; set; }

        public decimal Prize { get; set; }
    }
}