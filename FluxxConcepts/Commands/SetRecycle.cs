using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class SetRecycle : ICommand
    {
        public Guid ProcessId => new Guid("F0AA99AA-566D-488C-81C9-3CD542B181E3");

        public Guid Instance { get; }
        public string From { get; }
        public string To { get; }

        [Concept(Description = "Setup recycling between two card collections. This will trigger during a draw card action if the source card collection is depleted.")]
        public SetRecycle(string from, string to)
        {
            Instance = Guid.NewGuid();
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            if (From.Equals(To))
                throw new ArgumentException("The collections must not match.");
        }
    }
}
