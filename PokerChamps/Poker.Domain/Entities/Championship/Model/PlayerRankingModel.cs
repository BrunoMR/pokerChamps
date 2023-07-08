using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Entities.Championship.Model
{
    public class PlayerRankingModel
    {
        public PlayerRankingModel()
        {
        }

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

        public string PlayersId { get; private set; }

        public string Name { get; private set; }

        public double KoQuantity { get; private set; }

        //todo: remove set
        public int RebuyQuantity { get; private set; }
        
        public IList<Hand> SpecialHands { get; private set; }

        //todo: remove set
        public double Points { get; private set; }

        //todo: remove set
        public int? Position { get; private set; }

        //todo: remove set
        public decimal Prize { get; private set; }

        //todo: remove set
        public decimal Charge { get; private set; }
    }
}