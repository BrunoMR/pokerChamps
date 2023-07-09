using MongoDB.Bson.Serialization.Attributes;
using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class PlayerMatch
    {
        public PlayerMatch(){}
        
        public PlayerMatch(string playersId, string name, double koQuantity, int rebuyQuantity, double points,
            int? position, decimal prize, decimal charge)
        {
            PlayersId = playersId;
            Name = name;
            KoQuantity = koQuantity;
            RebuyQuantity = rebuyQuantity;
            Points = points;
            Position = position;
            Prize = prize;
            Charge = charge;
        }
        
        public PlayerMatch(string playersId, string name)
        {
            PlayersId = playersId;
            Name = name;
        }
        
        public PlayerMatch(string playersId, string name, int position)
        {
            PlayersId = playersId;
            Name = name;
            Position = position;
        }

        public string PlayersId { get; set; }

        public string Name { get; set; }

        [BsonElement("KoQuantity")]
        public double KoQuantity { get; private set; }

        [BsonElement("RebuyQuantity")]
        public int RebuyQuantity { get; private set; }

        [BsonElement("SpecialHands")]
        public IList<Hand> SpecialHands { get; private set; }

        [BsonElement("Points")]
        public double Points { get; private set; }

        [BsonElement("Position")]
        public int? Position { get; private set; }

        [BsonElement("Prize")]
        public decimal Prize { get; private set; }

        [BsonElement("Charge")]
        public decimal Charge { get; private set; }

        public void AddKo(double pointsToAdd, int koQuantity)
        {
            Points += pointsToAdd;
            KoQuantity += koQuantity;
        }

        public void AddRebuy(double points, decimal price)
        {
            RebuyQuantity += 1;
            Points += points;
            Charge += price;
        }

        public void AddBuyIn(decimal price)
        {
            Charge += price;
        }

        public void AddSpecialHand(HandsEnum hand, int points)
        {
            if (SpecialHands == null)
                SpecialHands = new List<Hand>();

            var specialHand = SpecialHands.FirstOrDefault(x => x.HandsEnum.ToString() == hand.ToString());

            if (specialHand == null)
                SpecialHands.Add(new Hand(hand.ToString()));
            else
                specialHand.AddQuantity();
            
            Points += points;
        }

        public void SetPosition(int position, int? points)
        {
            Position = position;
            Points += points ?? 10;
        }

        public void SetPrize(decimal netValue, decimal percentPrize)
        {
            Prize = netValue * percentPrize / 100;
        }
    }
}