namespace Poker.Api.v1.Dtos.Config;

public class TurnBlindsDto
{
    public int Time { get; set; }

    public decimal BlindValue { get; set; }

    public decimal BigBlindValue { get; set; }
}