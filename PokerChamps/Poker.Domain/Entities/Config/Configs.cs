using Poker.Domain.Entities.Base;
using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Domain.Entities.Config
{
    public class Configs : Entity
    {
        public Points Points { get; set; }

        public Prices Prices { get; set; }

        public List<TurnBlinds> TurnBlinds { get; set; }

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