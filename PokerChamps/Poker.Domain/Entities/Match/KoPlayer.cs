using Poker.Domain.Entities.Player;

namespace Poker.Domain.Entities.Match
{
    public class KoPlayer
    {
        public Players Player { get; set; }

        public double Percent { get; set; }
    }
}