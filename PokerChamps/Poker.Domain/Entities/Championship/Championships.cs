using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Championship
{
    public class Championships : Entity
    {
        public Championships(){}

        public Championships(string name, bool isOpen, DateOnly? dateInitial, DateOnly? dateFinal)
        {
            Name = name;
            IsOpen = isOpen;
            DateInitial = dateInitial;
            DateFinal = dateFinal;
        }
        
        [BsonElement("Name")]
        public string? Name { get; private set; }

        [BsonElement("IsOpen")]
        public bool IsOpen { get; private set; }

        [BsonElement("DateInitial")]
        public DateOnly? DateInitial { get; private set; }

        [BsonElement("DateFinal")]
        public DateOnly? DateFinal { get; private set; }

        [BsonElement("PrizePool")]
        public decimal PrizePool { get; private set; }

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