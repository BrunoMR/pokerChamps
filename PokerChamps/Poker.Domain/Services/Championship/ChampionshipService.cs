using System.Linq.Expressions;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Championship.Model;
using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Extensions;
using Poker.Domain.Services.Championship.Interfaces;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Championship;

public class ChampionshipService : IChampionshipService
{
    private readonly IQueryService<Championships> _queryService;
    private readonly IQueryService<Entities.Match.Match> _matchQueryService;
    private readonly IUpInsertService<Championships> _upInsertService;
    private readonly IQueryService<Configs> _configQueryService;

    public ChampionshipService(IQueryService<Championships> queryService,
        IQueryService<Entities.Match.Match> matchQueryService,
        IUpInsertService<Championships> upInsertService,
        IQueryService<Configs> configQueryService)
    {
        _queryService = queryService;
        _matchQueryService = matchQueryService;
        _upInsertService = upInsertService;
        _configQueryService = configQueryService;
    }

    public async Task<Championships> Get(Expression<Func<Championships, bool>> predicate)
    {
        return await _queryService.Get(predicate);
    }

    public async Task<IEnumerable<Championships>> GetList(Expression<Func<Championships, bool>> predicate)
    {
        return await _queryService.GetList(predicate);
    }

    public async Task<IEnumerable<Championships>> GetList(Championships championships)
    {
        var predicate = championships.CreateFilterPredicate<Championships>();
        return await _queryService.GetList(predicate);
    }

    public async Task<ChampionshipRankingModel> GetRanking(string id)
    {
        var matches = await _matchQueryService.GetList(x => x.ChampionshipId == id);

        var playerMatches = matches
            .SelectMany(m => m.Players)
            .GroupBy(g => g.PlayersId)
            .Select(p => 
                new PlayerRankingModel(p.Key,p.First().Name, p.Sum(x => x.KoQuantity), 
                p.Sum(x => x.RebuyQuantity), p.Sum(x => x.Points), null, 
                p.Sum(x => x.Prize), p.Sum(x => x.Charge)))
            .OrderByDescending(o => o.Points);

        var rowNumber = 0;
        var ranking = playerMatches.Select(x => new PlayerRankingModel(x.PlayersId, x.Name, x.KoQuantity,
            x.RebuyQuantity, x.Points, ++rowNumber, x.Prize, x.Charge));
        
        var championship = await _queryService.Get(x => x.Id == id);
        var awardes = await getAwardes(matches, championship);

        return new ChampionshipRankingModel(ranking, championship.PrizePool, awardes);
    }

    public async Task<(bool success, string reason)> UpdatePrizePool(Entities.Match.Match match)
    {
        var championship = await _queryService.Get(x => x.Id == match.ChampionshipId);
        
        championship.UpdatePrizePool(match.CashBoxSave);
        return await _upInsertService.Update(championship);
    }
    
    private async Task<IEnumerable<PrizeModel>> getAwardes(IEnumerable<Entities.Match.Match> matches, Championships championship)
    {
        var config = await _configQueryService.Get(x => x.Id == matches.First().ConfigId);
        var awardes = config.Prizes.Select(x => new PrizeModel(x.Position, championship.PrizePool * x.Value / 100));
        return awardes;
    }
}