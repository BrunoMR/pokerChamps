using Poker.Domain.Entities.Config;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Match;

public class MatchService : IMatchService
{
    private readonly IUpInsertService<Entities.Match.Match> _matchUpInsertService;
    private readonly IQueryService<Configs> _configsQueryService;

    public MatchService(IUpInsertService<Entities.Match.Match> matchUpInsertService,
        IQueryService<Configs> configsQueryService)
    {
        _matchUpInsertService = matchUpInsertService;
        _configsQueryService = configsQueryService;
    }
    
    public async Task<(bool success, string reason)> Create(Entities.Match.Match match)
    {
        var config = await _configsQueryService.Get(x => x.Id == match.ConfigId);
        
        match.AddBuyIn(match.Players.Count(), config.Prices.BuyIn);
        match.CalculateNetValue(config.Prices.CashBox);
        
        foreach (var matchPlayer in match.Players)
        {
            matchPlayer.AddBuyIn(config.Prices.BuyIn);
        }
        return await _matchUpInsertService.Create(match);
    }
}