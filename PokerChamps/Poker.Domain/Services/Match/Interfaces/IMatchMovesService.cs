using Poker.Domain.Entities.Match.Model;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Entities.Player;

namespace Poker.Domain.Services.Match.Interfaces;

public interface IMatchMovesService
{
    Task<(bool success, string reason)> NewKo(Ko ko, string matchId);
    
    Task<(bool success, string reason)> NewRebuys(IEnumerable<Players> players, string matchId);
    
    Task<(bool success, string reason)> NewSpecialHand(PlayerSpecialHandModel playerSpecialHand, string matchId);
}