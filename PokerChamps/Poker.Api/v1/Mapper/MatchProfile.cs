using AutoMapper;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Api.v1.Dtos.Match.Ko;
using Poker.Api.v1.Dtos.Match.Position;
using Poker.Api.v1.Dtos.Match.Query;
using Poker.Api.v1.Dtos.Match.SpecialHand;
using Poker.Domain.Entities.Match;
using Poker.Domain.Entities.Match.Model;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Mapper;

public class MatchProfile : Profile
{
    public MatchProfile()
    {
        CreateMap<PlayerSpecialHandModelDto, PlayerSpecialHandModel>(MemberList.None).ReverseMap();
        
        CreateMap<PlayersPositionDto, PlayerMatch>(MemberList.None)
            .ForMember(d => d.PlayersId, o => o.MapFrom(x => x.Id))
            .ReverseMap();
        
        CreateMap<HandDto, Hand>(MemberList.None).ReverseMap();
        CreateMap<PlayerMatchDto, PlayerMatch>(MemberList.None).ReverseMap();
        CreateMap<KoQueryDto, Ko>(MemberList.None).ReverseMap();

        CreateMap<MatchDto, Match>(MemberList.None)
            .ForMember(d => d.Players, o => o.MapFrom(x=> x.Players))
            .ForMember(d => d.Kos, o => o.MapFrom(x => x.Kos))
            .ReverseMap();
    }
}