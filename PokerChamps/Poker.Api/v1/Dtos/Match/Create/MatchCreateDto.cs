using System.ComponentModel.DataAnnotations;
using Poker.Api.v1.Dtos.Shared;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Dtos.Match.Create;

public class MatchCreateDto
{
    public MatchCreateDto(string? championshipId, string configId, IEnumerable<PlayerMatchCreateDto> players)
    {
        ChampionshipId = championshipId;
        ConfigId = configId;
        Players = players;
    }

    public string? ChampionshipId { get; set; }
    
    [Required(ErrorMessage = "É necessário selecionar ao menos uma configuração para ser utilizada na partida!")]
    public string ConfigId { get; set; }
    
    [Required]
    [PlayersCompliance]
    public IEnumerable<PlayerMatchCreateDto> Players { get; set; }
    
    public static implicit operator Domain.Entities.Match.Match(MatchCreateDto dto)
    {
        return new Domain.Entities.Match.Match(dto.ChampionshipId, dto.ConfigId, dto.Players.Select(x => (PlayerMatch)x));
    }
        
    public static implicit operator MatchCreateDto(Domain.Entities.Match.Match domain)
    {
        return new MatchCreateDto(domain.ChampionshipId, domain.ConfigId, domain.Players.Select(x => (PlayerMatchCreateDto)x));
    }
}