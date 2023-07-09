using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class KoPointsDto
{
    public KoPointsDto()
    {
        
    }
    
    private KoPointsDto(int maker, int receiver)
    {
        Maker = maker;
        Receiver = receiver;
    }

    public int Maker { get; set; }

    public int Receiver { get; set; }
    
    public static implicit operator KoPoints(KoPointsDto dto)
    {
        return new KoPoints(dto.Maker, dto.Receiver);
    }
        
    public static implicit operator KoPointsDto(KoPoints domain)
    {
        return new KoPointsDto(domain.Maker, domain.Receiver);
    }
}