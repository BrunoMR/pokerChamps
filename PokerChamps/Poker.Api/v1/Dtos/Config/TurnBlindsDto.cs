using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class TurnBlindsDto
{
    public TurnBlindsDto(){}

    private TurnBlindsDto(int time, decimal blindValue, decimal bigBlindValue)
    {
        Time = time;
        BlindValue = blindValue;
        BigBlindValue = bigBlindValue;
    }

    public int Time { get; set; }

    public decimal BlindValue { get; set; }

    public decimal BigBlindValue { get; set; }
    
    public static implicit operator TurnBlinds(TurnBlindsDto dto)
    {
        return new TurnBlinds(dto.Time, dto.BlindValue, dto.BigBlindValue);
    }
        
    public static implicit operator TurnBlindsDto(TurnBlinds domain)
    {
        return new TurnBlindsDto(domain.Time, domain.BlindValue, domain.BigBlindValue);
    }
}