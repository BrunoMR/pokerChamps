using System.ComponentModel.DataAnnotations;
using Poker.Api.v1.Dtos.Player;

namespace Poker.Api.v1.Dtos.Match.Ko;

public class KoPlayerDto
{
    [Required]
    public PlayersDto Player { get; set; }

    public double? Percent { get; set; }
}