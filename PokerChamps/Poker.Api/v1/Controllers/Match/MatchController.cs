using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Api.v1.Dtos.Match.Query;
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
            var (success, reason) = await _matchService.Create(_mapper.Map<Domain.Entities.Match.Match>(matchCreateDto));
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpGet("{championshipsId}")]
        public async Task<ActionResult<object>> GetAllByChampionshipId(string championshipsId)
        {
            var matchs = await _queryService.GetList(x => x.ChampionshipId == championshipsId);
            return StatusCode(200, _mapper.Map<MatchDto>(matchs));
        }
    }
}