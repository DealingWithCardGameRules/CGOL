using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class SetPlayers : ICommand
    {
        public Guid ProcessId => new Guid("5AFC9043-AEF6-4F45-BE54-588043CB4B3A");

        public Guid Instance { get; }
        public int Amount { get; }

        [Concept(Description = "Set the number of players.")]
        public SetPlayers(int amount)
        {
            Instance = Guid.NewGuid();
            Amount = amount;
        }
    }
}
