using Poker.Api.v1.Dtos.Match.Ko;

namespace Poker.Api.v1.Dtos.Match.Query;

public class MatchDto
{
    public MatchDto()
    {
        
    }
    
    private MatchDto(string? championshipId, string? configId, int buyInQuantity, decimal buyInValue, 
        int rebuyQuantity, decimal rebuyValue, decimal grossValue, decimal cashBoxSave, decimal placeValue, 
        decimal netValue, IEnumerable<PlayerMatchDto> players, IEnumerable<KoQueryDto> kos)
    {
        ChampionshipId = championshipId;
        ConfigId = configId;
        BuyInQuantity = buyInQuantity;
        BuyInValue = buyInValue;
        RebuyQuantity = rebuyQuantity;
        RebuyValue = rebuyValue;
        GrossValue = grossValue;
        CashBoxSave = cashBoxSave;
        PlaceValue = placeValue;
        NetValue = netValue;
        Players = players;
        Kos = kos;
    }

    public string? ChampionshipId { get; set; }
    
    public string? ConfigId { get; set; }
        
    public int? BuyInQuantity { get; set; }

    public decimal? BuyInValue { get; set; }

    public int? RebuyQuantity { get; set; }

    public decimal? RebuyValue { get; set; }

    public decimal? GrossValue { get; set; }
        
    public decimal? CashBoxSave { get; set; }

    public decimal? PlaceValue { get; set; }

    public decimal? NetValue { get; set; }

    public IEnumerable<PlayerMatchDto>? Players { get; set; }
    
    public IEnumerable<KoQueryDto>? Kos { get; set; }
    
    public static implicit operator MatchDto(Domain.Entities.Match.Match domain)
    {
        return new MatchDto(domain.ChampionshipId, domain.ConfigId, domain.BuyInQuantity, domain.BuyInValue,
            domain.RebuyQuantity, domain.RebuyValue, domain.GrossValue, domain.CashBoxSave, domain.PlaceValue, domain.NetValue,
            domain.Players.Select(x => (PlayerMatchDto)x), domain.Kos.Select(x => (KoQueryDto)x));
    }
}