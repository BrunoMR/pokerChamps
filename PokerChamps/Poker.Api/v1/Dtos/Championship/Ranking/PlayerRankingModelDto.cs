using Poker.Domain.Entities.Championship.Model;

namespace Poker.Api.v1.Dtos.Championship.Ranking
{
    public class PlayerRankingModelDto
    {
        public PlayerRankingModelDto(){}

        public PlayerRankingModelDto(string playersId, string name, double koQuantity, int rebuyQuantity, double points,
            int position, decimal prize, decimal charge)
        {
            PlayersId = playersId;
            Name = name;
            KoQuantity = koQuantity;
            RebuyQuantity = rebuyQuantity;
            Points = points;
            Position = position;
            Prize = prize;
            Charge = charge;
        }
        
        public string PlayersId { get; set; }

        public string Name { get; set; }
    
        public double KoQuantity { get; set; }
    
        public int RebuyQuantity { get; set; }

        public double Points { get; set; }
    
        public int? Position { get; set; }
    
        public decimal? Prize { get; set; }
    
        public decimal Charge { get; set; }
        
        public static implicit operator PlayerRankingModel(PlayerRankingModelDto dto)
        {
            return new PlayerRankingModel(dto.PlayersId, dto.Name, dto.KoQuantity, dto.RebuyQuantity, 
                dto.Points, (int)dto.Position, (decimal)dto.Prize, dto.Charge);
        }
        
        public static implicit operator PlayerRankingModelDto(PlayerRankingModel domain)
        {
            return new PlayerRankingModelDto(domain.PlayersId, domain.Name, domain.KoQuantity, domain.RebuyQuantity, 
                domain.Points, (int)domain.Position, domain.Prize, domain.Charge);
        }
    }
}