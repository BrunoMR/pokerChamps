using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Api.v1.Dtos.Match.Ko;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Match.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

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
        private readonly IQueryService<Domain.Entities.Match.Match> _queryService;
        
        public MatchKoController(ILogger<MatchKoController> logger, IMapper mapper, 
            IMatchKoService matchKoService,
                IQueryService<Domain.Entities.Match.Match> queryService)
        {
            _logger = logger;
            _mapper = mapper;
            _matchKoService = matchKoService;
            _queryService = queryService;
        }
        
        [HttpPost("{matchId}")]
        public async Task<ActionResult<object>> NewKo([FromBody] KoDto koDto, string matchId)
        {
            var (success, reason) = await _matchKoService.NewKo(_mapper.Map<Ko>(koDto), matchId);
            return StatusCode(!success ? 400 : 200);
        }
    }
}