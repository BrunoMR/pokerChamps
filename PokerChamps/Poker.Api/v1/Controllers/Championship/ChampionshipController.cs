using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Championship;
using Poker.Api.v1.Dtos.Championship.Ranking;
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
        private readonly IUpInsertService<Championships> _upInsertService;
        private readonly IChampionshipService _championshipService;

        public ChampionshipController(ILogger<ChampionshipController> logger, IMapper mapper, 
            IUpInsertService<Championships> upInsertService,
            IChampionshipService championshipService)
        {
            _logger = logger;
            _mapper = mapper;
            _upInsertService = upInsertService;
            _championshipService = championshipService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] ChampionshipsDto championshipsDto)
        {
            var (success, reason) = await _upInsertService.Create(_mapper.Map<Championships>(championshipsDto));
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put([FromBody] ChampionshipsDto championshipsDto, string id)
        {
            var championships = _mapper.Map<Championships>(championshipsDto);
            championships.SetId(id);
            
            var (success, reason) = await _upInsertService.Update(championships);
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
        
        [HttpGet("Ranking/{id}")]
        public async Task<ObjectResult> GetRanking(string id)
        {
            var championshipsEnumerable = await _championshipService.GetRanking(id);
            return StatusCode(200, _mapper.Map<ChampionshipRankingModelDto>(championshipsEnumerable));
        }
    }
}