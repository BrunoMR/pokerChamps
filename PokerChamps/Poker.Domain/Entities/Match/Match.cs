using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Entities.Base;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Entities.Match
{
    public class Match : Entity
    {
        public Match(){}

        public Match(string? championshipId, string configId, IEnumerable<PlayerMatch> players)
        {
            ChampionshipId = championshipId;
            ConfigId = configId;
            Players = players;
        }

        public bool IsOpen { get; set; } = true;
        
        public string? ChampionshipId { get; set; }

        public string? ConfigId { get; set; }

        [BsonElement("BuyInQuantity")]
        public int BuyInQuantity { get; private set; }

        [BsonElement("BuyInValue")]
        public decimal BuyInValue { get; private set; }

        [BsonElement("RebuyQuantity")]
        public int RebuyQuantity { get; private set; }

        [BsonElement("RebuyValue")]
        public decimal RebuyValue { get; private set; }

        [BsonElement("GrossValue")]
        public decimal GrossValue { get; private set; }

        [BsonElement("CashBoxSave")]
        public decimal CashBoxSave { get; private set; }

        [BsonElement("PlaceValue")]
        public decimal PlaceValue { get; private set; }

        [BsonElement("NetValue")]
        public decimal NetValue { get; private set; }

        public IEnumerable<PlayerMatch>? Players { get; set; }

        [BsonElement("Kos")]
        public IList<Ko>? Kos { get; private set; }

        public void AddBuyIn(int quantity, decimal price)
        {
            BuyInQuantity += quantity;
            BuyInValue = BuyInQuantity * price;
            AddToGrossValue(quantity * price);
        }

        public void AddKo(Ko newKo)
        {
            if (Kos == null)
                Kos = new List<Ko>();
            Kos.Add(newKo);
        }

        public void AddRebuy(int quantity, decimal rebuyPrice)
        {
            RebuyQuantity += quantity;
            RebuyValue = RebuyQuantity * rebuyPrice;
            AddToGrossValue(quantity * rebuyPrice);
        }

        public void CalculateNetValue(decimal percentCashBox)
        {
            CashBoxSave = GrossValue * percentCashBox / 100;
            NetValue = GrossValue - (CashBoxSave + PlaceValue);
        }

        public void EndGame()
        {
            IsOpen = false;
        }

        private void AddToGrossValue(decimal value)
        {
            GrossValue += value;
        }
    }
}