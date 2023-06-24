using System.Linq.Expressions;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Championship.Model;

namespace Poker.Domain.Services.Championship.Interfaces;

public interface IChampionshipService
{
    Task<Championships> Get(Expression<Func<Championships, bool>> predicate);
    
    Task<IEnumerable<Championships>> GetList(Expression<Func<Championships, bool>> predicate);
    
    Task<IEnumerable<Championships>> GetList(Championships championships);
    
    Task<ChampionshipRankingModel> GetRanking(string id);

    Task<(bool success, string reason)> UpdatePrizePool(Entities.Match.Match match);
}