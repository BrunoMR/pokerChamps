using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Match.Ko;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Services.Match.Interfaces;

namespace Poker.Api.v1.Controllers.Match
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class MatchKoController : ControllerBase
    {
        private readonly ILogger<MatchKoController> _logger;
        private readonly IMapper _mapper;
        private readonly IMatchKoService _matchKoService;

        public MatchKoController(ILogger<MatchKoController> logger, IMapper mapper, IMatchKoService matchKoService)
        {
            _logger = logger;
            _mapper = mapper;
            _matchKoService = matchKoService;
        }
        
        [HttpPost("{matchId}")]
        public async Task<ActionResult<object>> NewKo([FromBody] KoDto koDto, string matchId)
        {
            var (success, reason) = await _matchKoService.NewKo(_mapper.Map<Ko>(koDto), matchId);
            return StatusCode(!success ? 400 : 200);
        }
    }
}