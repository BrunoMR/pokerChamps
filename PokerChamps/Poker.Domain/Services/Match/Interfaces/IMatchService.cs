using Poker.Domain.Entities.Player;

namespace Poker.Domain.Services.Match.Interfaces;

public interface IMatchService
{
    Task<(bool success, string reason)> Create(Entities.Match.Match match);
}