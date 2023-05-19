using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Hand
    {
        public HandsEnum HandsEnum { get; set; }

        public int Quantity { get; set; }
    }
}