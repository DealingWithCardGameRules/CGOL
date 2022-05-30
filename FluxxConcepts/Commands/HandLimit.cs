using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class HandLimit : ICommand
    {
        public Guid ProcessId => new Guid("28FE0F8C-E2EA-4C87-A16A-69B7FF7A6529");

        public Guid Instance { get; }
        public int Limit { get; }
        public string DiscardPile { get; }

        [Concept(Description = "Set a limit on the amount of cards a player can have when it is not their turn. If they exceed the limit, they will immediately be asked to discard cards to the specified discardPile.")]
        public HandLimit(int limit, string discardPile)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
            DiscardPile = discardPile;
        }
    }
}
