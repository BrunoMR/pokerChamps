namespace Poker.Api.v1.Dtos.Config;

public class PrizesDto
{
    public int Position { get; set; }

    // In percent
    public decimal Value { get; set; }
}