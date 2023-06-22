using AutoMapper;
using Poker.Api.v1.Dtos.Config;
using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Config.Value_Objects;

namespace Poker.Api.v1.Mapper;

public class ConfigsProfile : Profile
{
    public ConfigsProfile()
    {
        CreateMap<PointsDto, Points>(MemberList.None).ReverseMap();
        CreateMap<PodiumPositionDto, PodiumPosition>(MemberList.None).ReverseMap();
        CreateMap<KoPointsDto, KoPoints>(MemberList.None).ReverseMap();
        CreateMap<HandsPointsDto, HandsPoints>(MemberList.None).ReverseMap();
        CreateMap<PricesDto, Prices>(MemberList.None).ReverseMap();
        CreateMap<TurnBlindsDto, TurnBlinds>(MemberList.None).ReverseMap();
        CreateMap<PrizesDto, Prizes>(MemberList.None).ReverseMap();
        
        CreateMap<ConfigsDto, Configs>(MemberList.None)
            .ForMember(d => d.Points, o => o.MapFrom(x => x.Points))
            .ForMember(d => d.Prices, o => o.MapFrom(x => x.Prices))
            .ForMember(d => d.TurnBlinds, o => o.MapFrom(x => x.TurnBlinds))
            .ForMember(d => d.Prizes, o => o.MapFrom(x => x.Prizes))
            .ReverseMap();
    }
}