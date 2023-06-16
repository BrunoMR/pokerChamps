using AutoMapper;
using Poker.Api.v1.Dtos.Config;
using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Mapper;

public class ConfigsProfile : Profile
{
    public ConfigsProfile()
    {
        CreateMap<PointsDto, Points>();
        CreateMap<PodiumPositionDto, PodiumPosition>();
        CreateMap<KoPointsDto, KoPoints>();
        CreateMap<HandsPointsDto, HandsPoints>();
        CreateMap<PricesDto, Prices>();
        CreateMap<ValuesDto, Values>();
        CreateMap<TurnBlindsDto, TurnBlinds>();
        
        CreateMap<ConfigsDto, Configs>()
            .ForMember(d => d.Points, o => o.MapFrom(x => x.Points))
            .ForMember(d => d.Prices, o => o.MapFrom(x => x.Prices))
            .ForMember(d => d.Values, o => o.MapFrom(x => x.Values))
            .ForMember(d => d.TurnBlinds, o => o.MapFrom(x => x.TurnBlinds));
    }
}