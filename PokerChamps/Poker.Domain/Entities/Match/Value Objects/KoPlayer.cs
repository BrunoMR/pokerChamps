using Poker.Domain.Entities.Player;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class KoPlayer
    {
        public Players Player { get; set; }

        public double? Percent { get; set; }

        public void SetPercent(int amoutPlayers)
        {
            Percent = 100 / amoutPlayers;
        }
    }
}