using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Match.Ko;
using Poker.Api.v1.Dtos.Match.SpecialHand;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Match.Model;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Entities.Player;
using Poker.Domain.Services.Match.Interfaces;

namespace Poker.Api.v1.Controllers.Match
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class MatchMovesController : ControllerBase
    {
        private readonly ILogger<MatchMovesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMatchMovesService _matchMovesService;

        public MatchMovesController(ILogger<MatchMovesController> logger, IMapper mapper, IMatchMovesService matchMovesService)
        {
            _logger = logger;
            _mapper = mapper;
            _matchMovesService = matchMovesService;
        }
        
        [HttpPost("{matchId}/new-ko")]
        public async Task<ActionResult<object>> NewKo([FromBody] KoDto koDto, string matchId)
        {
            var (success, reason) = await _matchMovesService.NewKo(_mapper.Map<Ko>(koDto), matchId);
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPost("{matchId}/new-rebuy")]
        public async Task<ActionResult<object>> NewRebuy([FromBody] IEnumerable<PlayersDto> playersDto, string matchId)
        {
            var (success, reason) = await _matchMovesService.NewRebuys(_mapper.Map<IEnumerable<Players>>(playersDto), matchId);
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPost("{matchId}/new-specialHand")]
        public async Task<ActionResult<object>> NewSpecialHand([FromBody] PlayerSpecialHandModelDto playerSpecialDto, string matchId)
        {
            var (success, reason) = await _matchMovesService.NewSpecialHand(_mapper.Map<PlayerSpecialHandModel>(playerSpecialDto), matchId);
            return StatusCode(!success ? 400 : 200);
        }
    }
}