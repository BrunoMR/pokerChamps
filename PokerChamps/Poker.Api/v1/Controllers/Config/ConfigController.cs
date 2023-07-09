using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Config;
using Poker.Domain.Entities.Config;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Api.v1.Controllers.Config
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;

        private readonly IUpInsertService<Configs> _upInsertService;
        private readonly IQueryService<Configs> _queryService;

        public ConfigController(ILogger<ConfigController> logger, 
            IUpInsertService<Configs> upInsertService,
            IQueryService<Configs> queryService)
        {
            _logger = logger;
            _upInsertService = upInsertService;
            _queryService = queryService;
        }
        
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] ConfigsDto configs)
        {
            var (success, reason) = await _upInsertService.Create(configs);
            return StatusCode(!success ? 400 : 200);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put([FromBody] ConfigsDto configsDto, string id)
        {
            var configs = (Configs)configsDto;
            configs.SetId(id);
            
            var (success, reason) = await _upInsertService.Update(configs);
            return StatusCode(!success ? 400 : 200);
        }

        [HttpGet]
        public async Task<ObjectResult> GetAll()
        {
            var configsEnumerable = await _queryService.GetList(x => x.Id != null);
            return StatusCode(200, configsEnumerable.Select(x => (ConfigsDto)x));
        }
        
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(string id)
        {
            var configs = await _queryService.Get(x => x.Id == id);
            return StatusCode(200, (ConfigsDto)configs);
        }
    }
}