using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CreateHand : ICommand
    {
        public Guid ProcessId => new Guid("F42D3FDC-048B-462A-8EC9-274A33F18DF5");

        public string Hand { get; }
        public int? PlayerIndex { get; }
        public Guid Instance { get; }

        [Concept(Description = "Create a hand. Assign a player to limit visibility for the hand.")]
        public CreateHand(string uniqueName, int owningPlayerIndex = -1)
        {
            Instance = Guid.NewGuid();
            Hand = uniqueName;
            if (owningPlayerIndex > -1)
                PlayerIndex = owningPlayerIndex;
        }
    }
}
