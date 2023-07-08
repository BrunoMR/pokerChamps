using Poker.Domain.Entities.Championship.Model;

namespace Poker.Api.v1.Dtos.Championship.Ranking;

public class ChampionshipRankingModelDto
{
    public ChampionshipRankingModelDto()
    {
    }

    public ChampionshipRankingModelDto(IEnumerable<PlayerRankingModelDto> playersRanking, decimal prizePool,
        IEnumerable<PrizeModelDto> prizes)
    {
        PlayersRanking = playersRanking;
        PrizePool = prizePool;
        Prizes = prizes;
    }

    public IEnumerable<PlayerRankingModelDto> PlayersRanking { get; set; }

    public decimal PrizePool { get; set; }

    public IEnumerable<PrizeModelDto> Prizes { get; set; }

    public static implicit operator ChampionshipRankingModel(ChampionshipRankingModelDto dto)
    {
        return new ChampionshipRankingModel(dto.PlayersRanking.Select(x => (PlayerRankingModel)x), dto.PrizePool,
            dto.Prizes.Select(x => (PrizeModel)x));
    }

    public static implicit operator ChampionshipRankingModelDto(ChampionshipRankingModel domain)
    {
        return new ChampionshipRankingModelDto(domain.PlayersRanking.Select(x => (PlayerRankingModelDto)x), domain.PrizePool,
            domain.Prizes.Select(x => (PrizeModelDto)x));
    }
}