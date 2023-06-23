namespace Poker.Api.v1.Dtos.Match.Query;

public class PlayerMatchDto
{
    public string PlayersId { get; set; }

    public string Name { get; set; }

    //todo: remove set
    public double KoQuantity { get; set; }

    //todo: remove set
    public int RebuyQuantity { get; set; }

    //todo: remove set
    public IList<HandDto> SpecialHands { get; set; }

    //todo: remove set
    public double Points { get; set; }

    //todo: remove set
    public int? Position { get; set; }

    //todo: remove set
    public decimal? Prize { get; set; }

    //todo: remove set
    public decimal Charge { get; set; }
}