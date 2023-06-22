using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Player;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Match;

public class MatchRebuyService : IMatchRebuyService
{
    private readonly IQueryService<Entities.Match.Match> _matchQueryService;
    private readonly IQueryService<Configs> _configsQueryService;
    private readonly IUpInsertService<Entities.Match.Match> _matchUpInsertService;

    public MatchRebuyService(IQueryService<Entities.Match.Match> matchQueryService,
        IQueryService<Configs> configsQueryService,
        IUpInsertService<Entities.Match.Match> matchUpInsertService)
    {
        _matchQueryService = matchQueryService;
        _configsQueryService = configsQueryService;
        _matchUpInsertService = matchUpInsertService;
    }
    
    public async Task<(bool success, string reason)> NewRebuys(IEnumerable<Players> players, string matchId)
    {
        var match = await _matchQueryService.Get(x => x.Id == matchId);
        var config = await _configsQueryService.Get(x => x.Id == match.ConfigId);
        
        match.AddRebuy(players.Count(), config.Prices.Rebuy);
        match.CalculateNetValue(config.Prices.CashBox);
        
        foreach (var player in players)
        {   
            match.Players
                ?.FirstOrDefault(p => p.PlayersId == player.Id)
                ?.AddRebuy(config.Points.Rebuy, config.Prices.Rebuy);
        }

        return await _matchUpInsertService.Update(match);
    }
}