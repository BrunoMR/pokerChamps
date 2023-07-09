using Poker.Domain.Entities.Match.Model;
using Poker.Domain.Enums;

namespace Poker.Api.v1.Dtos.Match.SpecialHand;

public class PlayerSpecialHandModelDto
{
    private PlayerSpecialHandModelDto(string playersId, string name, HandsEnum handsEnum)
    {
        PlayersId = playersId;
        Name = name;
        HandsEnum = handsEnum;
    }

    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public HandsEnum HandsEnum { get; set; }
    
    public static implicit operator PlayerSpecialHandModel(PlayerSpecialHandModelDto dto)
    {
        return new PlayerSpecialHandModel(dto.PlayersId, dto.Name, dto.HandsEnum);
    }
        
    public static implicit operator PlayerSpecialHandModelDto(PlayerSpecialHandModel domain)
    {
        return new PlayerSpecialHandModelDto(domain.PlayersId, domain.Name, domain.HandsEnum);
    }
}