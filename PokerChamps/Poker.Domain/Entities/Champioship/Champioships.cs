namespace Poker.Domain.Entities.Champioship
{
    public class Champioships
    {
        public string Name { get; set; }

        public bool IsOpen { get; set; }

        public DateOnly DateInitial { get; set; }

        public DateOnly DateFinal { get; set; }
    }
}