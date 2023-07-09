using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Dtos.Match.Position;

public class PlayersPositionDto
{
    private PlayersPositionDto(string playersId, string name, int position)
    {
        Id = playersId;
        Name = name;
        Position = position;
    }

    public string? Id { get; set; }

    public string Name { get; set; }

    public int Position { get; set; }

    public static implicit operator PlayerMatch(PlayersPositionDto dto)
    {
        return new PlayerMatch(dto.Id, dto.Name, dto.Position);
    }

    public static implicit operator PlayersPositionDto(PlayerMatch domain)
    {
        return new PlayersPositionDto(domain.PlayersId, domain.Name, (int)domain.Position);
    }
}