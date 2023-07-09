using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Dtos.Match.Query;

public class PlayerMatchDto
{
    public PlayerMatchDto()
    {
        
    }

    private PlayerMatchDto(string playersId, string name, double koQuantity, int rebuyQuantity, 
        IEnumerable<HandDto> hands, double points, int? position, decimal prize, decimal charge)
    {
        PlayersId = playersId;
        Name = name;
        KoQuantity = koQuantity;
        RebuyQuantity = rebuyQuantity;
        SpecialHands = hands;
        Points = points;
        Position = position;
        Prize = prize;
        Charge = charge;
    }

    public string PlayersId { get; set; }

    public string Name { get; set; }
    
    public double KoQuantity { get; set; }
    
    public int RebuyQuantity { get; set; }
    
    public IEnumerable<HandDto> SpecialHands { get; set; }
    
    public double Points { get; set; }
    
    public int? Position { get; set; }
    
    public decimal? Prize { get; set; }
    
    public decimal Charge { get; set; }
    
    public static implicit operator PlayerMatch(PlayerMatchDto dto)
    {
        return new PlayerMatch(dto.PlayersId, dto.Name, dto.KoQuantity, dto.RebuyQuantity,
            dto.Points, dto.Position, (decimal)dto.Prize, dto.Charge);
    }
        
    public static implicit operator PlayerMatchDto(PlayerMatch domain)
    {
        return new PlayerMatchDto(domain.PlayersId, domain.Name, domain.KoQuantity, domain.RebuyQuantity,
            domain.SpecialHands.Select(x => (HandDto)x), domain.Points, domain.Position, domain.Prize, domain.Charge);
    }
}