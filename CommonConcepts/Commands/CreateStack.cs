using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CreateStack : ICommand
    {
        public Guid ProcessId => new Guid("BB4E3338-8973-4D07-8892-983B3E617C95");

        public Guid StackId { get; }

        public CreateStack(Guid stackId)
        {
            StackId = stackId;
        }
    }
}
