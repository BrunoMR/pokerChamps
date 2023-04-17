namespace Poker.Domain.Entities.Match
{
    public class Ko
    {
        public IEnumerable<KoPlayer> Maker { get; set; }

        public IEnumerable<KoPlayer> Receiver { get; set; }
    }
}