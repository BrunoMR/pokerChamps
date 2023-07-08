using System.Text.Json.Serialization;
using Poker.Api.Shared;
using Poker.Domain.Entities.Championship;

namespace Poker.Api.v1.Dtos.Championship;

public class ChampionshipsDto
{
    public ChampionshipsDto(){}

    public ChampionshipsDto(string id, string name, bool isOpen, DateOnly dateInitial, DateOnly dateFinal)
    {
        Id = id;
        Name = name;
        IsOpen = isOpen;
        DateInitial = dateInitial;
        DateFinal = dateFinal;
    }
    
    public string? Id { get; set; }
    
    public string? Name { get; set; }

    public bool? IsOpen { get; set; }

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly? DateInitial { get; set; }

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly? DateFinal { get; set; }

    public static implicit operator Championships(ChampionshipsDto dto)
    {
        return new Championships(dto.Name, (bool)dto.IsOpen, dto.DateInitial, dto.DateFinal);
    }
    
    public static implicit operator ChampionshipsDto(Championships domain)
    {
        return new ChampionshipsDto(domain.Id, domain.Name, (bool)domain.IsOpen, (DateOnly)domain.DateInitial, (DateOnly)domain.DateFinal);
    }
}