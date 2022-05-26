using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class KeeperLimit : ICommand
    {
        public Guid ProcessId => new Guid("047CDFF7-8563-4B36-BA6B-C96C16FFE14F");

        public Guid Instance { get; }
        public int Limit { get; }
        public string DiscardPile { get; }

        public KeeperLimit(int limit, string discardPile)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
            DiscardPile = discardPile;
        }
    }
}
