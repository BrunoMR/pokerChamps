using System.ComponentModel.DataAnnotations;
using Poker.Api.v1.Dtos.Shared;

namespace Poker.Api.v1.Dtos.Match.Create;

public class MatchCreateDto
{
    public string? ChampionshipId { get; set; }
    
    [Required(ErrorMessage = "É necessário selecionar ao menos uma configuração para ser utilizada na partida!")]
    public string ConfigId { get; set; }
    
    // [Required(ErrorMessage = "É necessário selecionar ao menos um jogador para a partida!")]
    [Required]
    [PlayersCompliance]
    public IEnumerable<PlayerMatchCreateDto> Players { get; set; }
}