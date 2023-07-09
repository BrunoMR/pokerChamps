using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Dtos.Match.Create;

public class PlayerMatchCreateDto
{
    public PlayerMatchCreateDto(string playersId, string name)
    {
        PlayersId = playersId;
        Name = name;
    }

    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public static implicit operator PlayerMatch(PlayerMatchCreateDto dto)
    {
        return new PlayerMatch(dto.PlayersId, dto.Name);
    }
        
    public static implicit operator PlayerMatchCreateDto(Players domain)
    {
        return new PlayerMatchCreateDto(domain.Id, domain.Name);
    }
    
    public static implicit operator PlayerMatchCreateDto(PlayerMatch domain)
    {
        return new PlayerMatchCreateDto(domain.PlayersId, domain.Name);
    }
}