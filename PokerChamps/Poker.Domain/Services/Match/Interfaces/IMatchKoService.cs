using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Domain.Services.Match.Interfaces;

public interface IMatchKoService
{
    Task<(bool success, string reason)> NewKo(Ko ko, string matchId);
}