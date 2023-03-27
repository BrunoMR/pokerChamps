using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match
{
    public class Hand
    {
        public HandsEnum HandsEnum { get; set; }

        public int Quantity { get; set; }
    }
}