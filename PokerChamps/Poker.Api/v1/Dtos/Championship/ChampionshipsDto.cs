using System.Text.Json.Serialization;
using Poker.Api.Shared;

namespace Poker.Api.v1.Dtos.Championship;

public class ChampionshipsDto
{
    public string? Id { get; set; }
    
    public string? Name { get; set; }

    public bool? IsOpen { get; set; }

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly? DateInitial { get; set; }

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly? DateFinal { get; set; }
}