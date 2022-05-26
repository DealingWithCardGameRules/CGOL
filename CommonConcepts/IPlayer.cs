namespace dk.itu.game.msc.cgol.CommonConcepts
{
    public interface IPlayer : ITagable
    {
        public int Index { get; }
        public string Name { get; }
        public string Identity { get; }
    }
}
