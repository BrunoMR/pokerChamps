using Poker.Domain.Entities.Player;

namespace Poker.Domain.Services.Match.Interfaces;

public interface IMatchRebuyService
{
    Task<(bool success, string reason)> NewRebuys(IEnumerable<Players> players, string matchId);
}