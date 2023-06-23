using System.ComponentModel.DataAnnotations;
using Poker.Api.v1.Dtos.Player;

namespace Poker.Api.v1.Dtos.Match.Ko;

public class KoQueryDto
{
    [Required]
    public IEnumerable<PlayersDto> Makers { get; set; }
    
    public double? PointsByMaker { get; set; }
    
    [Required]
    public IEnumerable<PlayersDto> Receivers { get; set; }
}