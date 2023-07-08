using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Player;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Api.v1.Controllers.Player
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IUpInsertService<Players> _upInsertService;
        private readonly IQueryService<Players> _queryService;

        public PlayerController(ILogger<PlayerController> logger, 
            IUpInsertService<Players> upInsertService,
            IQueryService<Players> queryService)
        {
            _logger = logger;
            _upInsertService = upInsertService;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] PlayersDto playersDto)
        {
            var (success, reason) = await _upInsertService.Create(playersDto);
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put([FromBody] PlayersDto playerDto, string id)
        {
            Players players = playerDto;
            players.SetId(id);
            
            var (success, reason) = await _upInsertService.Update(players);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpGet]
        public async Task<ObjectResult> GetAll()
        {
            var playersEnumerable = await _queryService.GetList(x => x.Id != null);
            return StatusCode(200, playersEnumerable.Select(x => (PlayersDto)x));
        }
        
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(string id)
        {
            var players = await _queryService.Get(x => x.Id == id);
            return StatusCode(200, (PlayersDto)players);
        }
    }
}