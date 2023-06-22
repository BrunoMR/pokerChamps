using Poker.Domain.Entities.Player;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Ko
    {
        public IEnumerable<Players> Maker { get; set; }

        //todo: remove set
        public double PointsByMaker { get; set; }
        // => 15 / Maker.Count();

        public IEnumerable<Players> Receiver { get; set; }

        public void SetPointsByMaker(double points)
        {
            PointsByMaker = points / Maker.Count();
        }
    }
} 