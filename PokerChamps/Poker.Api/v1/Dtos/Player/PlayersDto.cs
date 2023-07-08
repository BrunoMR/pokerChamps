using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Dtos.Player;

public class PlayersDto
{
    public PlayersDto(string? id, string name)
    {
        Id = id;
        Name = name;
    }

    public string? Id { get; set; }
    
    public string Name { get; set; }
    
    public static implicit operator Players(PlayersDto dto)
    {
        return new Players(dto.Name);
    }
        
    public static implicit operator PlayersDto(Players domain)
    {
        return new PlayersDto(domain.Id, domain.Name);
    }
}