namespace Poker.Api.v1.Dtos.Config;

public class ConfigsDto
{
    public PointsDto Points { get; set; }
    
    public PricesDto Prices { get; set; }
    
    public ValuesDto Values { get; set; }
    
    public List<TurnBlindsDto> TurnBlinds { get; set; }    
}