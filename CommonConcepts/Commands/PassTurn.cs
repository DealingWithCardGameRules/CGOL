using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PassTurn : ICommand
    {
        public Guid ProcessId => new Guid("C3729CA3-E42F-49AC-A695-E051A8A397FE");

        public Guid Instance { get; }

        [Concept(Description = "End the turn for the current player, increment the current player index (wrap around max players) and start a new turn.")]
        public PassTurn()
        {
            Instance = Guid.NewGuid();
        }
    }
}
