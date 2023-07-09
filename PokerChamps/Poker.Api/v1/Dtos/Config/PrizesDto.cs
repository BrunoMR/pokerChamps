using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class PrizesDto
{
    public PrizesDto(int position, decimal value)
    {
        Position = position;
        Value = value;
    }

    public int Position { get; set; }

    // In percent
    public decimal Value { get; set; }
    
    public static implicit operator Prizes(PrizesDto dto)
    {
        return new Prizes(dto.Position, dto.Value);
    }
        
    public static implicit operator PrizesDto(Prizes domain)
    {
        return new PrizesDto(domain.Position, domain.Value);
    }
}