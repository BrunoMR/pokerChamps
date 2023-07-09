using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Api.v1.Dtos.Match.Position;
using Poker.Api.v1.Dtos.Match.Query;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;

namespace Poker.Api.v1.Controllers.Match
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;
        private readonly IMapper _mapper;
        private readonly IMatchService _matchService;
        private readonly IQueryService<Domain.Entities.Match.Match> _queryService;

        public MatchController(ILogger<MatchController> logger, IMapper mapper,
            IMatchService matchService,
            IQueryService<Domain.Entities.Match.Match> queryService)
        {
            _logger = logger;
            _mapper = mapper;
            _matchService = matchService;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] MatchCreateDto matchCreateDto)
        {
            var (success, reason) = await _matchService.Create(matchCreateDto);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpPost("{matchId}/set-players-positions")]
        public async Task<ActionResult<object>> SetPlayerPosition(
            [FromBody] IEnumerable<PlayersPositionDto> playersPositionDtos, string matchId)
        {
            var (success, reason) =
                await _matchService.SetPlayersPosition(_mapper.Map<IEnumerable<PlayerMatch>>(playersPositionDtos),
                    matchId);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<object>> EndGame(string id)
        {
            var (success, reason) = await _matchService.EndGame(id);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(string id)
        {
            var match = await _queryService.Get(x => x.Id == id);
            return StatusCode(200, _mapper.Map<MatchDto>(match));
        }

        [HttpGet("byChampionshipId/{championshipsId}")]
        public async Task<ActionResult<object>> GetAllByChampionshipId(string championshipsId)
        {
            var matchs = await _queryService.GetList(x => x.ChampionshipId == championshipsId);
            return StatusCode(200, _mapper.Map<IEnumerable<MatchDto>>(matchs));
        }
    }
}