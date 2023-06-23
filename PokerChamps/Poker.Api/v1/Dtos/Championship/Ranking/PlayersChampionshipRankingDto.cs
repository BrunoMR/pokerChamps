namespace Poker.Api.v1.Dtos.Championship.Ranking;

public class PlayersChampionshipRankingDto
{
    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public double KoQuantity { get; set; }
    
    public int RebuyQuantity { get; set; }
    
    public double Points { get; set; }
    
    public int? Position { get; set; }
    
    public decimal Prize { get; set; }
    
    public decimal Charge { get; set; }
}