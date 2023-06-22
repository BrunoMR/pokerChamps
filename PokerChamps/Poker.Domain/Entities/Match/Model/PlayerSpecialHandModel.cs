using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match.Model;

public class PlayerSpecialHandModel
{
    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public HandsEnum HandsEnum { get; set; }
}