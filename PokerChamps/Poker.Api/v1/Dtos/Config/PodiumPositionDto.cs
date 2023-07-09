using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class PodiumPositionDto
{
    public PodiumPositionDto()
    {
        
    }
    
    private PodiumPositionDto(int position, int points)
    {
        Position = position;
        Points = points;
    }

    public int Position { get; set; }

    public int Points { get; set; }
    
    public static implicit operator PodiumPosition(PodiumPositionDto dto)
    {
        return new PodiumPosition(dto.Position, dto.Points);
    }
        
    public static implicit operator PodiumPositionDto(PodiumPosition domain)
    {
        return new PodiumPositionDto(domain.Position, domain.Points);
    }
}