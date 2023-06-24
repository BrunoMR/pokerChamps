namespace Poker.Api.v1.Dtos.Championship.Ranking;

public class ChampionshipRankingModelDto
{
    public IEnumerable<PlayerRankingModelDto> PlayersRanking { get; set; }
    
    public decimal PrizePool { get; set; }
    
    public IEnumerable<PrizeModelDto> Prizes { get; set; }
}