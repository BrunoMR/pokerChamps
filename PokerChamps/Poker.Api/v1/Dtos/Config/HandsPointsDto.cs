using Poker.Domain.Entities.Config.Value_Objects;
using Poker.Domain.Enums;

namespace Poker.Api.v1.Dtos.Config;

public class HandsPointsDto
{
    public HandsPointsDto()
    {
        
    }
    
    private HandsPointsDto(HandsEnum type, int value)
    {
        Type = type;
        Value = value;
    }

    public HandsEnum Type { get; set; }

    public int Value { get; set; }
    
    public static implicit operator HandsPoints(HandsPointsDto dto)
    {
        return new HandsPoints(dto.Type, dto.Value);
    }
        
    public static implicit operator HandsPointsDto(HandsPoints domain)
    {
        return new HandsPointsDto(domain.Type, domain.Value);
    }
}