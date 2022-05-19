using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DiscardCards : ICommand
    {
        public Guid ProcessId => new Guid("B189B600-08D1-4CA7-83C1-5D7C7F1B6987");
        public Guid Instance { get; }
        public string Source { get; }
        public IEnumerable<string>? Tags { get; }
        public string Destination { get; }

        [Concept(Description = "Discard cards from a collection of cards to another collection. If tags are set, only cars with those specific tags are discarded.")]
        public DiscardCards(string from, string to, string tags = null)
        {
            Instance = Guid.NewGuid();
            Source = from;
            Destination = to;
            if (tags != null)
                Tags = tags.CommaSeperateTrimmed();
        }
    }
}
