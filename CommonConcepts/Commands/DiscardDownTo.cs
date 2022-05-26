using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class DiscardDownTo : ICommand
    {
        public Guid ProcessId => new Guid("F1884D87-BE82-4B2B-BADD-44FA653A86F7");

        public Guid Instance { get; }
        public string From { get; }
        public int Size { get; }
        public string To { get; }

        [Concept(Description = "Ask a player to discard cards down to a given size.")]
        public DiscardDownTo(string from, int size, string to)
        {
            Instance = Guid.NewGuid();
            From = from ?? throw new ArgumentNullException(nameof(from));
            Size = size;
            To = to ?? throw new ArgumentNullException(nameof(to));
        }
    }
}
