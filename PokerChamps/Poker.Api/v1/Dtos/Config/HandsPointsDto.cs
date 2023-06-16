using Poker.Domain.Enums;

namespace Poker.Api.v1.Dtos.Config;

public class HandsPointsDto
{
    public HandsEnum Type { get; set; }

    public int Value { get; set; }
}