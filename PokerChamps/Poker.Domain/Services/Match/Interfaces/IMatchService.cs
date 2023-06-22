using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Services.Match.Interfaces;

public interface IMatchService
{
    Task<(bool success, string reason)> Create(Entities.Match.Match match);
    
    Task<(bool success, string reason)> SetPlayersPosition(IEnumerable<PlayerMatch> playersMatch, string matchId);
}