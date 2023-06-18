using AutoMapper;
using Poker.Api.v1.Dtos.Match;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Domain.Entities.Match;

namespace Poker.Api.v1.Mapper;

public class MatchProfile : Profile
{
    public MatchProfile()
    {
        CreateMap<MatchCreateDto, Match>(MemberList.None)
            .ReverseMap();
    }
}