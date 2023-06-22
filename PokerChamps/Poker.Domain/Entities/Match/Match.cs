using Poker.Domain.Entities.Base;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Entities.Match
{
    public class Match : Entity
    {
        public string? ChampionshipId { get; set; }
        
        public string? ConfigId { get; set; }
        
        //todo: remove set
        public int BuyInQuantity { get; set; }

        //todo: remove set
        public decimal BuyInValue { get; set; }

        //todo: remove set
        public int RebuyQuantity { get; set; }

        //todo: remove set
        public decimal RebuyValue { get; set; }

        public decimal GrossValue { get; set; }
        
        public decimal CashBoxSave { get; set; }

        public decimal PlaceValue { get; set; }

        public decimal NetValue { get; set; }

        public IEnumerable<PlayerMatch>? Players { get; set; }

        //todo: remove set
        public IList<Ko>? Kos { get; set; }

        public void AddKo(Ko newKo)
        {
            if (Kos == null)
                Kos = new List<Ko>();
            Kos.Add(newKo);
        }

        public void AddRebuy()
        {
            RebuyQuantity += 1;
        }
    }
}