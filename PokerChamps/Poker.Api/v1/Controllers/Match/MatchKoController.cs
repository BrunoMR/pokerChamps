using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Domain.Services.Config.Interfaces;
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
        private readonly ICreateService<Domain.Entities.Match.Match> _createService;
        private readonly IQueryService<Domain.Entities.Match.Match> _queryService;
    
        public MatchKoController(ILogger<MatchKoController> logger, IMapper mapper, 
            ICreateService<Domain.Entities.Match.Match> createService,
            IQueryService<Domain.Entities.Match.Match> queryService)
        {
            _logger = logger;
            _mapper = mapper;
            _createService = createService;
            _queryService = queryService;
        }
        
        [HttpPost]
        public async Task<ActionResult<object>> NewKo([FromBody] MatchCreateDto matchCreateDto)
        {
            var (success, reason) = await _createService.Create(_mapper.Map<Domain.Entities.Match.Match>(matchCreateDto));
            return StatusCode(!success ? 400 : 200);
        }
    }
}