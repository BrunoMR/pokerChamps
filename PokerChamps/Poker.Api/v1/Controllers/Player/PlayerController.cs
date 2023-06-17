using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ICreateService<Players> _createService;
        private readonly IQueryService<Players> _queryService;

        public PlayerController(ILogger<PlayerController> logger, IMapper mapper, 
            ICreateService<Players> createService,
            IQueryService<Players> queryService)
        {
            _logger = logger;
            _mapper = mapper;
            _createService = createService;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] PlayersDto playersDto)
        {
            var (success, reason) = await _createService.Create(_mapper.Map<Players>(playersDto));
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put([FromBody] PlayersDto playerDto, string id)
        {
            var players = _mapper.Map<Players>(playerDto);
            players.SetId(id);
            
            var (success, reason) = await _createService.Update(players);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpGet]
        public async Task<ObjectResult> GetAll()
        {
            var playersEnumerable = await _queryService.GetList(x => x.Id != null);
            return StatusCode(200, _mapper.Map<IEnumerable<PlayersDto>>(playersEnumerable));
        }
        
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(string id)
        {
            var players = await _queryService.Get(x => x.Id == id);
            return StatusCode(200, _mapper.Map<PlayersDto>(players));
        }
    }
}