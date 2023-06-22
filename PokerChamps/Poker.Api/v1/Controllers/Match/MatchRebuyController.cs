using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Player;
using Poker.Domain.Services.Match.Interfaces;

namespace Poker.Api.v1.Controllers.Match
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class MatchRebuyController : ControllerBase
    {
        private readonly ILogger<MatchRebuyController> _logger;
        private readonly IMapper _mapper;
        private readonly IMatchRebuyService _matchRebuyService;

        public MatchRebuyController(ILogger<MatchRebuyController> logger, IMapper mapper, IMatchRebuyService matchRebuyService)
        {
            _logger = logger;
            _mapper = mapper;
            _matchRebuyService = matchRebuyService;
        }
        
        [HttpPost("{matchId}")]
        public async Task<ActionResult<object>> Post([FromBody] IEnumerable<PlayersDto> playersDto, string matchId)
        {
            var (success, reason) = await _matchRebuyService.NewRebuys(_mapper.Map<IEnumerable<Players>>(playersDto), matchId);
            return StatusCode(!success ? 400 : 200);
        }
    }
}