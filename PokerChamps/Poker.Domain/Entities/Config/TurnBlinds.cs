namespace Poker.Domain.Entities.Config
{
    public class TurnBlinds
    {
        public int Time { get; set; }

        public decimal BlindValue { get; set; }

        public decimal BigBlindValue { get; set; }
    }
}