using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Hand
    {
        public Hand(){}

        public Hand(string hand)
        {
            HandsEnum = hand;
            Quantity += 1;
        }
        
        public string HandsEnum { get; set; }

        public int Quantity { get; set; }

        public void AddQuantity()
        {
            Quantity += 1;
        }
    }
}