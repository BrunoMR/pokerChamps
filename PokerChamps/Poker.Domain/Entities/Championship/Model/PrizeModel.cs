namespace Poker.Domain.Entities.Championship.Model
{
    public class PrizeModel
    {
        public PrizeModel(){}

        public PrizeModel(int position, decimal value)
        {
            Position = position;
            Value = value;
        }
        
        public int Position { get; set; }

        public decimal Value { get; set; }
    }
}