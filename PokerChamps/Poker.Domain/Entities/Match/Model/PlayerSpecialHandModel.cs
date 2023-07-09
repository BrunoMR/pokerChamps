using Poker.Domain.Enums;

namespace Poker.Domain.Entities.Match.Model;

public class PlayerSpecialHandModel
{
    public PlayerSpecialHandModel(){}

    public PlayerSpecialHandModel(string playersId, string name, HandsEnum handsEnum)
    {
        PlayersId = playersId;
        Name = name;
        HandsEnum = handsEnum;
    }


    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public HandsEnum HandsEnum { get; set; }
}