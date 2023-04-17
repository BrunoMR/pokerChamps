using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Poker.Domain.Entities.Match;
using Poker.Domain.Entities.Player;
using Poker.Infrastructure.Repositories;

namespace Poker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<Players> _playersRepository;

        public MatchController(ILogger<WeatherForecastController> logger, 
            IRepository<Match> matchRepository,
            IRepository<Players> playersRepository)
        {
            _logger = logger;
            _matchRepository = matchRepository;
            _playersRepository = playersRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _matchRepository.GetAllByFilterAsync(x => x.NetValue > 1000);
            _playersRepository.InsertOneAsync(new Players());

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }
    }
}