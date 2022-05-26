using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class CreateCard : ICommand
    {
        public Guid ProcessId => new Guid("DE353A49-5525-4366-9D07-6FBB96F33DFA");

        public string Template { get; }

        public Guid Instance { get; }

        [Concept(Description = "Create a card template with a unique name. It's possible to attach effects to the template and later create an instance using the AddCard concept.")]
        public CreateCard(string uniqueCardName)
        {
            Instance = Guid.NewGuid();
            Template = uniqueCardName;
        }
    }
}
