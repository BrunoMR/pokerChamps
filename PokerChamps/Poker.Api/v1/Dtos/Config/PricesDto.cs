using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Dtos.Config;

public class PricesDto
{
    public PricesDto(){}

    private PricesDto(decimal cashBox, decimal buyIn, decimal rebuy)
    {
        CashBox = cashBox;
        BuyIn = buyIn;
        Rebuy = rebuy;
    }

    public decimal CashBox { get; set; }
    
    public decimal BuyIn { get; set; }

    public decimal Rebuy { get; set; }
    
    public static implicit operator Prices(PricesDto dto)
    {
        return new Prices(dto.CashBox, dto.BuyIn, dto.Rebuy);
    }
        
    public static implicit operator PricesDto(Prices domain)
    {
        return new PricesDto(domain.CashBox, domain.BuyIn, domain.Rebuy);
    }
}