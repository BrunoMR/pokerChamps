using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Services.Championship.Interfaces;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Domain.Services.Match;

public class MatchService : IMatchService
{
    private readonly IUpInsertService<Entities.Match.Match> _matchUpInsertService;
    private readonly IQueryService<Configs> _configsQueryService;
    private readonly IQueryService<Entities.Match.Match> _matchQueryService;
    private readonly IChampionshipService _championshipService;

    public MatchService(IUpInsertService<Entities.Match.Match> matchUpInsertService,
        IQueryService<Configs> configsQueryService,
        IQueryService<Entities.Match.Match> matchQueryService,
        IChampionshipService championshipService)
    {
        _matchUpInsertService = matchUpInsertService;
        _configsQueryService = configsQueryService;
        _matchQueryService = matchQueryService;
        _championshipService = championshipService;
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

    public async Task<(bool success, string reason)> SetPlayersPosition(IEnumerable<PlayerMatch> playersMatch,
        string matchId)
    {
        var (match, config) = await getMatchAndConfig(matchId);
        
        if (match is null || !match.IsOpen)
        {
            return (false, "Jogo não encontrado ou já encerrado!");
        }

        foreach (var player in playersMatch)
        {
            var pointsByPosition =
                config.Points.PodiumPosition.FirstOrDefault(x => x.Position == player.Position)?.Points;

            match.Players
                ?.FirstOrDefault(p => p.PlayersId == player.PlayersId)
                ?.SetPosition((int)player.Position, pointsByPosition);
        }

        return await _matchUpInsertService.Update(match);
    }

    public async Task<(bool success, string reason)> EndGame(string id)
    {
        var (match, config) = await getMatchAndConfig(id);
        
        if (match is null || !match.IsOpen)
        {
            return (false, "Jogo não encontrado ou já encerrado!");
        }

        foreach (var award in config.Prizes)
        {
            var playerPositionToAwarded = match.Players.FirstOrDefault(x => x.Position == award.Position);
            playerPositionToAwarded.SetPrize(match.NetValue, award.Value);
        }

        match.EndGame();
        await _championshipService.UpdatePrizePool(match);
        return await _matchUpInsertService.Update(match);
    }

    private async Task<(Entities.Match.Match, Configs)> getMatchAndConfig(string id)
    {
        var match = await _matchQueryService.Get(x => x.Id == id);
        if (match is null)
            return (null, null);
        var config = await _configsQueryService.Get(x => x.Id == match.ConfigId);
        return (match, config);
    }
}