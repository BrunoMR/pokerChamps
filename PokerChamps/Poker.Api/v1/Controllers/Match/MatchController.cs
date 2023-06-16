using Microsoft.AspNetCore.Mvc;
using Poker.Domain.Adapters.Repositories;
using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Controllers.Match
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;
        private readonly IRepository<Domain.Entities.Match.Match> _matchRepository;
        private readonly IRepository<Players> _playersRepository;

        public MatchController(ILogger<MatchController> logger, 
            IRepository<Domain.Entities.Match.Match> matchRepository,
            IRepository<Players> playersRepository)
        {
            _logger = logger;
            _matchRepository = matchRepository;
            _playersRepository = playersRepository;
        }

        // [HttpGet(Name = "GetWeatherForecast")]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     _matchRepository.GetAllByFilterAsync(x => x.NetValue > 1000);
        //     _playersRepository.InsertOneAsync(new Players());
        //
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //         TemperatureC = Random.Shared.Next(-20, 55)
        //     })
        //     .ToArray();
        // }
    }
}