using Poker.Domain.Enums;

namespace Poker.Api.v1.Dtos.Match.SpecialHand;

public class PlayerSpecialHandModelDto
{
    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public HandsEnum HandsEnum { get; set; }
}