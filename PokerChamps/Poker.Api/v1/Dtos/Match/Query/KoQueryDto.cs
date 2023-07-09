using System.ComponentModel.DataAnnotations;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Dtos.Match.Ko;

public class KoQueryDto
{
    public KoQueryDto()
    {
        
    }
    
    private KoQueryDto(IEnumerable<PlayersDto> makers, double pointsByMaker, IEnumerable<PlayersDto> receivers)
    {
        Makers = makers;
        PointsByMaker = pointsByMaker;
        Receivers = receivers;
    }

    [Required]
    public IEnumerable<PlayersDto> Makers { get; set; }
    
    public double? PointsByMaker { get; set; }
    
    [Required]
    public IEnumerable<PlayersDto> Receivers { get; set; }
    
    public static implicit operator Domain.Entities.Match.Value_Objects.Ko(KoQueryDto dto)
    {
        return new Domain.Entities.Match.Value_Objects.Ko(dto.Makers.Select(x => (Players)x),
            dto.Receivers.Select(x => (Players)x));
    }
        
    public static implicit operator KoQueryDto(Domain.Entities.Match.Value_Objects.Ko domain)
    {
        return new KoQueryDto(domain.Makers.Select(x => (PlayersDto)x),
            domain.PointsByMaker,
            domain.Receivers.Select(x => (PlayersDto)x));
    }
}