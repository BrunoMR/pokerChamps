using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Championship;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Services.Championship.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Api.v1.Controllers.Championship
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class ChampionshipController : ControllerBase
    {
        private readonly ILogger<ChampionshipController> _logger;
        private readonly IMapper _mapper;
        private readonly ICreateService<Championships> _createService;
        private readonly IChampionshipService _championshipService;

        public ChampionshipController(ILogger<ChampionshipController> logger, IMapper mapper, 
            ICreateService<Championships> createService,
            IChampionshipService championshipService)
        {
            _logger = logger;
            _mapper = mapper;
            _createService = createService;
            _championshipService = championshipService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] ChampionshipsDto championshipsDto)
        {
            var (success, reason) = await _createService.Create(_mapper.Map<Championships>(championshipsDto));
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put([FromBody] ChampionshipsDto championshipsDto, string id)
        {
            var championships = _mapper.Map<Championships>(championshipsDto);
            championships.SetId(id);
            
            var (success, reason) = await _createService.Update(championships);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpGet]
        public async Task<ObjectResult> GetAll()
        {
            var championshipsEnumerable = await _championshipService.GetList(x => x.Id != null);
            return StatusCode(200, _mapper.Map<IEnumerable<ChampionshipsDto>>(championshipsEnumerable));
        }
        
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(string id)
        {
            var championships = await _championshipService.Get(x => x.Id == id);
            return StatusCode(200, _mapper.Map<ChampionshipsDto>(championships));
        }
        
        [HttpPost("ByConditions")]
        public async Task<ObjectResult> AllByConditions([FromBody] ChampionshipsDto championshipsDto)
        {
            var championshipsEnumerable = await _championshipService.GetList(_mapper.Map<Championships>(championshipsDto));
            return StatusCode(200, _mapper.Map<IEnumerable<ChampionshipsDto>>(championshipsEnumerable));
        }
    }
}