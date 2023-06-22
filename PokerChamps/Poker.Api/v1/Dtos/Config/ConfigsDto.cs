namespace Poker.Api.v1.Dtos.Config;

public class ConfigsDto
{
    public string? Id { get; set; }

    public PointsDto Points { get; set; }

    public PricesDto Prices { get; set; }

    public List<TurnBlindsDto> TurnBlinds { get; set; }
    
    public List<PrizesDto> Prizes { get; set; }
}