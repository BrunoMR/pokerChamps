using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Player
{
    public class Players : Entity
    {
        public Players(){}
        
        public Players(string name)
        {
            Name = name;
        }
        
        public string Name { get; private set; }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}