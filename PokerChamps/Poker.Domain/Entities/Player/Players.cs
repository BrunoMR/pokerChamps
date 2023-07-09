using Poker.Domain.Entities.Base;

namespace Poker.Domain.Entities.Player
{
    public class Players : Entity
    {
        public Players(){}
        
        public Players(string id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public string Name { get; private set; }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}