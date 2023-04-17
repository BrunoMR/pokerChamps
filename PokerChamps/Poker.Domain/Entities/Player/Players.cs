using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Player
{
    public class Players : Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}