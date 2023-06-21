using AutoMapper;
using Poker.Api.v1.Dtos.Match.Ko;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Mapper;

public class KoProfile : Profile
{
    public KoProfile()
    {
        // CreateMap<KoPlayerDto, KoPlayer>(MemberList.None).ReverseMap();

        // ShouldMapProperty = info => info.GetMethod.IsPublic || info.GetMethod.IsAssembly; 
        
        CreateMap<KoDto, Ko>(MemberList.None)
            .ForMember(d => d.Maker, o => o.MapFrom(x => x.Makers))
            .ForMember(d => d.Receiver, o => o.MapFrom(x => x.Receivers))
            .ReverseMap();
    }
}