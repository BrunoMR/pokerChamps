using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Match.Model;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Entities.Player;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Match;

public class MatchMovesService : IMatchMovesService
{
    private readonly IQueryService<Entities.Match.Match> _matchQueryService;
    private readonly IQueryService<Configs> _configsQueryService;
    private readonly IUpInsertService<Entities.Match.Match> _matchUpInsertService;

    public MatchMovesService(IQueryService<Entities.Match.Match> matchQueryService,
        IQueryService<Configs> configsQueryService,
        IUpInsertService<Entities.Match.Match> matchUpInsertService)
    {
        _matchQueryService = matchQueryService;
        _configsQueryService = configsQueryService;
        _matchUpInsertService = matchUpInsertService;
    }

    public async Task<(bool success, string reason)> NewKo(Ko ko, string matchId)
    {
        var (match, config) = await getMatchAndConfig(matchId);
        var matchIsValid = validateMatch(match);

        if (!matchIsValid.Item1)
            return matchIsValid;
        
        ko.SetPointsByMaker(config.Points.Ko.Maker);
        match.AddKo(ko);

        var quantityReceivers = ko.Receivers.Count();
        foreach (var maker in ko.Makers)
        {
            match.Players
                ?.FirstOrDefault(p => p.PlayersId == maker.Id)
                ?.AddKo(ko.PointsByMaker * quantityReceivers, quantityReceivers);
        }

        return await _matchUpInsertService.Update(match);
    }

    public async Task<(bool success, string reason)> NewRebuys(IEnumerable<Players> players, string matchId)
    {
        var (match, config) = await getMatchAndConfig(matchId);
        var matchIsValid = validateMatch(match);

        if (!matchIsValid.Item1)
            return matchIsValid;
        
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

    public async Task<(bool success, string reason)> NewSpecialHand(PlayerSpecialHandModel playerSpecialHand,
        string matchId)
    {
        var (match, config) = await getMatchAndConfig(matchId);
        var matchIsValid = validateMatch(match);

        if (!matchIsValid.Item1)
            return matchIsValid;
        
        var pointsToAdd = config.Points.HandsPoints.FirstOrDefault(x => x.Type == playerSpecialHand.HandsEnum).Value;

        match.Players
            ?.FirstOrDefault(p => p.PlayersId == playerSpecialHand.PlayersId)
            ?.AddSpecialHand(playerSpecialHand.HandsEnum, pointsToAdd);


        return await _matchUpInsertService.Update(match);
    }

    private async Task<(Entities.Match.Match, Configs)> getMatchAndConfig(string matchId)
    {
        var match = await _matchQueryService.Get(x => x.Id == matchId);
        var config = await _configsQueryService.Get(x => x.Id == match.ConfigId);
        return (match, config);
    }
    
    private (bool, string) validateMatch(Entities.Match.Match match)
    {
        return match is null ? (false, "Jogo não encontrado ou já encerrado!") : (true, string.Empty);
    }
}