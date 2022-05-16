using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class HandLimit : ICommand
    {
        public Guid ProcessId => new Guid("28FE0F8C-E2EA-4C87-A16A-69B7FF7A6529");

        public Guid Instance { get; }
        public int Limit { get; }
        public string DiscardPile { get; }

        public HandLimit(int limit, string discardPile)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
            DiscardPile = discardPile;
        }
    }
}
