using System.ComponentModel.DataAnnotations;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Dtos.Match.Ko;

public class KoDto
{
    public KoDto() {}
    
    public KoDto(IEnumerable<PlayersDto> makers, IEnumerable<PlayersDto> receivers)
    {
        Makers = makers;
        Receivers = receivers;
    }

    [Required]
    public IEnumerable<PlayersDto> Makers { get; set; }

    [Required]
    public IEnumerable<PlayersDto> Receivers { get; set; }
    
    public static implicit operator Domain.Entities.Match.Value_Objects.Ko(KoDto dto)
    {
        return new Domain.Entities.Match.Value_Objects.Ko(dto.Makers.Select(x => (Players)x), dto.Receivers.Select(x => (Players)x));
    }
        
    public static implicit operator KoDto(Domain.Entities.Match.Value_Objects.Ko domain)
    {
        return new KoDto(domain.Makers.Select(x => (PlayersDto)x), domain.Receivers.Select(x => (PlayersDto)x));
    }
}