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
            .Select(p => new PlayerMatch
            {
                PlayersId = p.Key,
                Name = p.First().Name,
                Points = p.Sum(x => x.Points),
                Prize = p.Sum(x => x.Prize),
                KoQuantity = p.Sum(x => x.KoQuantity),
                RebuyQuantity = p.Sum(x => x.RebuyQuantity),
                Charge = p.Sum(x => x.Charge)
            }).OrderByDescending(o => o.Points);

        var rowNumber = 0;
        var ranking = playerMatches.Select(x => new PlayerMatch
        {
            Position = ++rowNumber,
            PlayersId = x.PlayersId,
            Name = x.Name,
            Points = x.Points,
            Prize = x.Prize,
            KoQuantity = x.KoQuantity,
            RebuyQuantity = x.RebuyQuantity,
            Charge = x.Charge
        });

        return ranking;
    }
}