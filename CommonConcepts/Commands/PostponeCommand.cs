using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PostponeCommand : ICommand
    {
        public Guid ProcessId => new Guid("85A8EA4B-4945-4F41-B3CC-C4A127F00DC9");

        public ICommand Command { get; }
        public string? Label { get; }
        public Guid Instance { get; }

        private Guid? cardRef;

        [AffectSelf]
        public Guid? SelfRef
        {
            get
            {
                return cardRef;
            }
            set
            {
                cardRef = value;
                if (value.HasValue)
                {
                    Command.SetAffactSelfRef(value.Value);
                }
            }
        }

        public PostponeCommand(ICommand command, string? label = null)
        {
            Instance = Guid.NewGuid();
            Command = command;
            Label = label;
        }
    }
}
