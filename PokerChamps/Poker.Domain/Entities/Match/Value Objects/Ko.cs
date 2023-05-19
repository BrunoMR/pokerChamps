namespace Poker.Domain.Entities.Match.Value_Objects
{
    public class Ko
    {
        public IEnumerable<KoPlayer> Maker { get; set; }

        public IEnumerable<KoPlayer> Receiver { get; set; }
    }
}