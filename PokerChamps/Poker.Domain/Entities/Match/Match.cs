
using Poker.Domain.Entities.Base;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Entities.Match
{
    public class Match : Entity
    {
        public int BuyInQuantity { get; set; }

        public decimal BuyInValue { get; set; }

        public int RebuyQuantity { get; set; }

        public decimal RebuyValue { get; set; }

        public decimal GrossValue { get; set; }
        
        public decimal CashBoxSave { get; set; }

        public decimal PlaceValue { get; set; }

        public decimal NetValue { get; set; }

        public IEnumerable<PlayerMatch> Players { get; set; }

        public IEnumerable<Ko> Kos { get; set; }
    }
}