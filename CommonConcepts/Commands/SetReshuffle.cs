using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class SetReshuffle : ICommand
    {
        public Guid ProcessId => new Guid("F0AA99AA-566D-488C-81C9-3CD542B181E3");
        public Guid Instance { get; }
        public string From { get; }
        public string To { get; }

        [Concept(Description = "Set up a rule to reshuffle from collection into to collection if the to collection is empty. This is triggered by a draw/deal action.")]
        public SetReshuffle(string from, string to)
        {
            Instance = Guid.NewGuid();
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            if (From.Equals(To))
                throw new ArgumentException("The collections must not match.");
        }
    }
}
