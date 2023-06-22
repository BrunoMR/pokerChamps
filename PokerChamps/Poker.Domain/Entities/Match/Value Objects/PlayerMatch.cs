namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class PlayerMatch
    {
        public string PlayersId { get; set; }
        
        public string Name { get; set; }
        
        //todo: remove set
        public double KoQuantity { get; set; }

        //todo: remove set
        public int RebuyQuantity { get; set; }

        //todo: remove set
        public IEnumerable<Hand> Hands { get; set; }

        //todo: remove set
        public double Points { get; set; }

        //todo: remove set
        public int Position { get; set; }

        //todo: remove set
        public decimal Prize { get; set; }
        
        //todo: remove set
        public decimal Charge { get; set; }

        public void AddKo(double pointsToAdd)
        {
            KoQuantity += 1;
            Points += pointsToAdd;
        }

        public void AddRebuy(double points, decimal price)
        {
            RebuyQuantity += 1;
            Points += points;
            Charge += price;
        }
    }
}