using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Player
{
    public class Players : Entity
    {
        public string Name { get; set; }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}