using System.Linq.Expressions;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Extensions;
using Poker.Domain.Services.Championship.Interfaces;
using Poker.Domain.Services.Config.Interfaces;

namespace Poker.Domain.Services.Championship;

public class ChampionshipService : IChampionshipService
{
    private readonly IQueryService<Championships> _queryService;
    private readonly IQueryService<Entities.Match.Match> _matchQueryService;

    public ChampionshipService(IQueryService<Championships> queryService,
        IQueryService<Entities.Match.Match> matchQueryService)
    {
        _queryService = queryService;
        _matchQueryService = matchQueryService;
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
        var predicteBuilt = championships.CreateFilterPredicate<Championships>();
        return await _queryService.GetList(predicteBuilt);
    }

    public async Task<IEnumerable<PlayerMatch>> GetRanking(string id)
    {
        var matches = await _matchQueryService.GetList(x => x.ChampionshipId == id);

        var playerMatches = matches
            .SelectMany(m => m.Players)
            .GroupBy(g => g.PlayersId)
            .Select(p => 
                new PlayerMatch(p.Key,p.First().Name, p.Sum(x => x.KoQuantity), 
                p.Sum(x => x.RebuyQuantity), p.Sum(x => x.Points), null, 
                p.Sum(x => x.Prize), p.Sum(x => x.Charge)))
            .OrderByDescending(o => o.Points);

        var rowNumber = 0;
        var ranking = playerMatches.Select(x => new PlayerMatch(x.PlayersId, x.Name, x.KoQuantity,
            x.RebuyQuantity, x.Points, ++rowNumber, x.Prize, x.Charge));

        return ranking;
    }
}