using Poker.Api.v1.Mapper;

namespace Poker.Api.Extensions
{
    public static class ProfileInjectionExtension
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigsProfile));
            services.AddAutoMapper(typeof(PlayersProfile));
            services.AddAutoMapper(typeof(ChampionshipsProfile));

            return services;
        }
    }
}