using Poker.Domain.Entities.Player;

namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Ko
    {
        public IEnumerable<Players> Makers { get; set; }

        //todo: remove set
        public double PointsByMaker { get; set; }

        public IEnumerable<Players> Receivers { get; set; }

        public void SetPointsByMaker(double points)
        {
            PointsByMaker = points / Makers.Count();
        }
    }
}