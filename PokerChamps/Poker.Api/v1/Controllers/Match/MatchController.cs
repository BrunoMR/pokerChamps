using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared.Interfaces;

namespace Poker.Api.v1.Controllers.Match
{
    // [ApiController]
    // [ApiVersion("1.0")]
    // [Route("v{api-version:apiVersion}/[controller]")]
    // public class MatchController : ControllerBase
    // {
    //     private readonly ILogger<MatchController> _logger;
    //     private readonly IMapper _mapper;
    //     private readonly ICreateService<Domain.Entities.Match.Match> _createService;
    //     private readonly IQueryService<Domain.Entities.Match.Match> _queryService;
    //
    //     public MatchController(ILogger<MatchController> logger, IMapper mapper, 
    //         ICreateService<Domain.Entities.Match.Match> createService,
    //         IQueryService<Domain.Entities.Match.Match> queryService)
    //     {
    //         _logger = logger;
    //         _mapper = mapper;
    //         _createService = createService;
    //         _queryService = queryService;
    //     }
    //
    //     // [HttpGet(Name = "GetWeatherForecast")]
    //     // public IEnumerable<WeatherForecast> Get()
    //     // {
    //     //     _matchRepository.GetAllByFilterAsync(x => x.NetValue > 1000);
    //     //     _playersRepository.InsertOneAsync(new Players());
    //     //
    //     //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     //     {
    //     //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //     //         TemperatureC = Random.Shared.Next(-20, 55)
    //     //     })
    //     //     .ToArray();
    //     // }
    // }
}