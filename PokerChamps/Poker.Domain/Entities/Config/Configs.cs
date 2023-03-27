namespace Poker.Domain.Entities.Config
{
    public class Configs
    {
        public Points Points { get; set; }

        public Prices Prices { get; set; }

        public Values Values { get; set; }

        public IEnumerable<TurnBlinds> TurnBlinds { get; set; }

        public Configs() { }
    }
}