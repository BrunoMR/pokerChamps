using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Entities.Championship.Model
{
    public class PlayerRankingModel
    {
        public PlayerRankingModel(){}
        
        public PlayerRankingModel(string playersId, string name, double koQuantity, int rebuyQuantity, double points,
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

        public string PlayersId { get; set; }

        public string Name { get; set; }

        //todo: remove set
        public double KoQuantity { get; set; }

        //todo: remove set
        public int RebuyQuantity { get; set; }

        //todo: remove set
        public IList<Hand> SpecialHands { get; set; }

        //todo: remove set
        public double Points { get; set; }

        //todo: remove set
        public int? Position { get; set; }

        //todo: remove set
        public decimal Prize { get; set; }

        //todo: remove set
        public decimal Charge { get; set; }
    }
}