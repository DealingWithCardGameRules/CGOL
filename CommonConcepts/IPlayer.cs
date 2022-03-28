namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface IPlayer : ITagable
    {
        public int Index { get; }
        public string Name { get; }
        public string Identity { get; }
    }
}
