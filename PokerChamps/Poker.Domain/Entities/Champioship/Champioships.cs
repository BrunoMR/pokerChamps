using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Champioship
{
    public class Champioships : Entity
    {
        public string Name { get; set; }

        public bool IsOpen { get; set; }

        public DateOnly DateInitial { get; set; }

        public DateOnly DateFinal { get; set; }
    }
}