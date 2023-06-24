using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Championship
{
    public class Championships : Entity
    {
        public string? Name { get; set; }

        public bool IsOpen { get; set; }

        public DateOnly? DateInitial { get; set; }

        public DateOnly? DateFinal { get; set; }

        public decimal PrizePool { get; set; }

        public void SetId(string id)
        {
            Id = id;
        }

        public void UpdatePrizePool(decimal cash)
        {
            PrizePool += cash;
        }
    }
}