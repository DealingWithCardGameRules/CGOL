using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DiscardCards : ICommand
    {
        public Guid ProcessId => new Guid("B189B600-08D1-4CA7-83C1-5D7C7F1B6987");
        public Guid Instance { get; }
        public string Source { get; }
        public IEnumerable<string> Tags { get; }
        public string Destination { get; }

        [Concept(Description = "Discard cards with specific tags from a collection of card to an other collection.")]
        public DiscardCards(string from, string tags, string to)
        {
            Instance = Guid.NewGuid();
            Source = from;
            Tags = tags.GetTagsTrimmed();
            Destination = to;
        }
    }
}
