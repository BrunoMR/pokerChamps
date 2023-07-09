using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class PointsDto
{
    public PointsDto()
    {
        
    }
    
    private PointsDto(double rebuy, IEnumerable<PodiumPositionDto> podiumPosition, KoPoints ko, 
        IEnumerable<HandsPointsDto> handsPoints)
    {
        Rebuy = rebuy;
        PodiumPosition = podiumPosition;
        Ko = ko;
        HandsPoints = handsPoints;
    }

    public double Rebuy { get; set; }

    public IEnumerable<PodiumPositionDto> PodiumPosition { get; set; }

    public KoPointsDto Ko { get; set; }

    public IEnumerable<HandsPointsDto> HandsPoints { get; set; }
    
    public static implicit operator Points(PointsDto dto)
    {
        return new Points(dto.Rebuy, dto.PodiumPosition.Select(x => (PodiumPosition)x), 
            dto.Ko, dto.HandsPoints.Select(x => (HandsPoints)x));
    }
        
    public static implicit operator PointsDto(Points domain)
    {
        return new PointsDto(domain.Rebuy, domain.PodiumPosition.Select(x => (PodiumPositionDto)x), 
            domain.Ko, domain.HandsPoints.Select(x => (HandsPointsDto)x));
    }
}