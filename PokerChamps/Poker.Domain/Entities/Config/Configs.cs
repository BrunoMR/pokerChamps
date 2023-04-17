using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Config
{
    public class Configs : Entity
    {
        public Points Points { get; set; }

        public Prices Prices { get; set; }

        public Values Values { get; set; }

        public List<TurnBlinds> TurnBlinds { get; set; }

        public void SetPoints(Points points)
        {
            Points = points;
        }

        public void SetPrices(Prices prices)
        {
            Prices = prices;
        }

        public void SetValues(Values values)
        {
            Values = values;
        }

        public void SetTurnBlinds(TurnBlinds turnBlinds)
        {
            if (turnBlinds != null)
                TurnBlinds = new List<TurnBlinds>();

            TurnBlinds.Add(turnBlinds);
        }
    }
}