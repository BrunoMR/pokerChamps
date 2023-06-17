namespace Poker.Api.v1.Dtos.Config;

public class PointsDto
{
    public decimal Rebuy { get; set; }

    public List<PodiumPositionDto> PodiumPosition { get; set; }

    public KoPointsDto Ko { get; set; }

    public List<HandsPointsDto> HandsPoints { get; set; }
}