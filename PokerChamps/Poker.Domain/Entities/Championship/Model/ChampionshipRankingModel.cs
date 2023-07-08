namespace Poker.Domain.Entities.Championship.Model;

public class ChampionshipRankingModel
{
    public ChampionshipRankingModel(){}

    public ChampionshipRankingModel(IEnumerable<PlayerRankingModel> players, decimal prizePool, IEnumerable<PrizeModel> prizes)
    {
        PlayersRanking = players;
        PrizePool = prizePool;
        Prizes = prizes;
    }
    public IEnumerable<PlayerRankingModel> PlayersRanking { get; set; }
    
    public decimal PrizePool { get; set; }
    
    public IEnumerable<PrizeModel> Prizes { get; set; }
}