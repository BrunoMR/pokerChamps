using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Config.Value_Objects
{
    public class HandsPoints
    {
        public HandsEnum Type { get; set; }

        public int Value { get; set; }
    }
}