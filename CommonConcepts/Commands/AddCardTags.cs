using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class AddCardTags : ICommand
    {
        public Guid ProcessId => new Guid("1783F4F4-7570-454C-904E-4CD32E53539A");

        public Guid Instance { get; }
        public string Card { get; }
        public IEnumerable<string> Tags { get; }

        [Concept(Description = "Add tags to a card template. Refer to the template by the unique card template name and a comma separated list of tags.")]
        public AddCardTags(string card, string tags)
        {
            if (tags is null)
                throw new ArgumentNullException(nameof(tags));

            Instance = Guid.NewGuid();
            Card = card ?? throw new ArgumentNullException(nameof(card));
            Tags = tags.CommaSeperateTrimmed();
        }

    }
}
