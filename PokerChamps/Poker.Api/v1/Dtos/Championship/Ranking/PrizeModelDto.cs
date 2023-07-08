using Poker.Domain.Entities.Championship.Model;

namespace Poker.Api.v1.Dtos.Championship.Ranking
{
    public class PrizeModelDto
    {
        public PrizeModelDto(){}
        
        public PrizeModelDto(int position, decimal value)
        {
            Position = position;
            Value = value;
        }

        public int Position { get; set; }

        public decimal Value { get; set; }
        
        public static implicit operator PrizeModel(PrizeModelDto dto)
        {
            return new PrizeModel(dto.Position, dto.Value);
        }
        
        public static implicit operator PrizeModelDto(PrizeModel domain)
        {
            return new PrizeModelDto(domain.Position, domain.Value);
        }
    }
}