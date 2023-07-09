using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class ConfigsDto
{
    public ConfigsDto()
    {
        
    }
    
    private ConfigsDto(string id, PointsDto points, PricesDto prices, IEnumerable<TurnBlindsDto> turnBlinds, 
        IEnumerable<PrizesDto> prizes)
    {
        Id = id;
        Points = points;
        Prices = prices;
        TurnBlinds = turnBlinds;
        Prizes = prizes;
    }

    public string? Id { get; set; }

    public PointsDto Points { get; set; }

    public PricesDto Prices { get; set; }

    public IEnumerable<TurnBlindsDto> TurnBlinds { get; set; }
    
    public IEnumerable<PrizesDto> Prizes { get; set; }
    
    public static implicit operator Configs(ConfigsDto dto)
    {
        return new Configs(dto.Id, dto.Points, dto.Prices, 
            dto.TurnBlinds.Select(x => (TurnBlinds)x),
            dto.Prizes.Select(x => (Prizes)x));
    }
        
    public static implicit operator ConfigsDto(Configs domain)
    {
        return new ConfigsDto(domain.Id, domain.Points, domain.Prices, 
            domain.TurnBlinds.Select(x => (TurnBlindsDto)x),
            domain.Prizes.Select(x => (PrizesDto)x));
    }
}