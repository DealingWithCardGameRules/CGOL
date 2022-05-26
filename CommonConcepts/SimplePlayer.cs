namespace dk.itu.game.msc.cgol.CommonConcepts
{
    internal class SimplePlayer : TagHandler, IPlayer
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public string Identity { get; set; }
    }
}
