using Poker.Api.v1.Dtos.Match.Ko;

namespace Poker.Api.v1.Dtos.Match.Query;

public class MatchDto
{
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
}