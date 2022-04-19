using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PassTurn : ICommand
    {
        public Guid ProcessId => new Guid("C3729CA3-E42F-49AC-A695-E051A8A397FE");

        public Guid Instance { get; }

        public PassTurn()
        {
            Instance = Guid.NewGuid();
        }
    }
}
