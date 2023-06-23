using System.Linq.Expressions;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Services.Championship.Interfaces;

public interface IChampionshipService
{
    Task<Championships> Get(Expression<Func<Championships, bool>> predicate);
    
    Task<IEnumerable<Championships>> GetList(Expression<Func<Championships, bool>> predicate);
    
    Task<IEnumerable<Championships>> GetList(Championships championships);
    
    Task<IEnumerable<PlayerMatch>> GetRanking(string id);
}