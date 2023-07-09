using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Dtos.Match.Query;

public class HandDto
{
    public HandDto()
    {
    }

    private HandDto(string handsEnum, int quantity)
    {
        HandsEnum = handsEnum;
        Quantity = quantity;
    }

    public string HandsEnum { get; set; }

    public int Quantity { get; set; }

    public static implicit operator Hand(HandDto dto)
    {
        return new Hand(dto.HandsEnum);
    }

    public static implicit operator HandDto(Hand domain)
    {
        return new HandDto(domain.HandsEnum, domain.Quantity);
    }
}