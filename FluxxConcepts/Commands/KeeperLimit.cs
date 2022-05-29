using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
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

        [Concept(Description = "Set a limit on the amount of keeper cards a player can have when it is not their turn. If they exceed the limit, they will immediately be asked to discard cards to the specified discardPile.")]
        public KeeperLimit(int limit, string discardPile)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
            DiscardPile = discardPile;
        }
    }
}
