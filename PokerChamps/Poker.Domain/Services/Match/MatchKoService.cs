using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Match;

public class MatchKoService : IMatchKoService
{
    private readonly IQueryService<Entities.Match.Match> _matchQueryService;
    private readonly IQueryService<Configs> _configsQueryService;
    private readonly IUpInsertService<Entities.Match.Match> _matchUpInsertService;

    public MatchKoService(IQueryService<Entities.Match.Match> matchQueryService,
        IQueryService<Configs> configsQueryService,
        IUpInsertService<Entities.Match.Match> matchUpInsertService)
    {
        _matchQueryService = matchQueryService;
        _configsQueryService = configsQueryService;
        _matchUpInsertService = matchUpInsertService;
    }
    
    public async Task<(bool success, string reason)> NewKo(Ko ko, string matchId)
    {
        var match = await _matchQueryService.Get(x => x.Id == matchId);
        var config = await _configsQueryService.Get(x => x.Id == match.ConfigId);

        ko.SetPointsByMaker(config.Points.Ko.Maker);
        match.AddKo(ko);
        
        foreach (var maker in ko.Maker)
        {   
            match.Players
                ?.FirstOrDefault(p => p.PlayersId == maker.Id)
                ?.AddKo(ko.PointsByMaker);
        }

        return await _matchUpInsertService.Update(match);
    }
}