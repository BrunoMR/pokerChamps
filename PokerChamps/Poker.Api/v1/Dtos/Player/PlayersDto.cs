using System.ComponentModel.DataAnnotations;

namespace Poker.Api.v1.Dtos.Player;

public class PlayersDto
{
    public string? Id { get; set; }
    
    public string Name { get; set; }
}