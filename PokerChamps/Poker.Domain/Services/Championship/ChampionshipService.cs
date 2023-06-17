using System.Linq.Expressions;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Extensions;
using Poker.Domain.Services.Championship.Interfaces;
using Poker.Domain.Services.Config.Interfaces;

namespace Poker.Domain.Services.Championship;

public class ChampionshipService : IChampionshipService
{
    private readonly IQueryService<Championships> _queryService;

    public ChampionshipService(IQueryService<Championships> queryService)
    {
        _queryService = queryService;
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
}