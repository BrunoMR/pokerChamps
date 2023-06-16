using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Api.v1.Dtos.Config;
using Poker.Domain.Entities.Config;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Api.v1.Controllers.Config
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;
        private readonly IMapper _mapper;
        
        private readonly ICreateService<Configs> _createService;

        public ConfigController(ILogger<ConfigController> logger, IMapper mapper, ICreateService<Configs> createService)
        {
            _logger = logger;
            _mapper = mapper;
            _createService = createService;
        }

        // [HttpPost(Name = "New")]
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] ConfigsDto configs)
        {
            var (success, reason) = await _createService.Create(_mapper.Map<Configs>(configs));
            return StatusCode(!success ? 400 : 200);
        }

        // [HttpGet(Name = "GetWeatherForecast")]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //         TemperatureC = Random.Shared.Next(-20, 55)
        //     })
        //     .ToArray();
        // }
    }
}