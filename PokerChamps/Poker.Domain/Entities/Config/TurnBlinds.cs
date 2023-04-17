namespace Poker.Domain.Entities.Config
{
    public class TurnBlinds
    {
        // in seconds
        public int Time { get; set; }

        public decimal BlindValue { get; set; }

        public decimal BigBlindValue { get; set; }

        public TurnBlinds(int time, decimal blindValue, decimal bigBlindValue)
        {
            Time = time;
            BlindValue = blindValue;
            BigBlindValue = bigBlindValue;
        }
    }
}