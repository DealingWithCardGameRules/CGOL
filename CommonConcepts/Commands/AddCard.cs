using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class AddCard : ICommand
    {
        public Guid ProcessId => new Guid("C41ED5BD-D463-4B29-BD77-BCAB6FCF1853");
        [PlayCollection] public string Destination { get; }
        public string Template { get; }

        public Guid Instance { get; }

        [Concept(Description = "Create an instance of a card template and add it to a collection.")]
        public AddCard(string uniqueCardName, string collection)
        {
            Instance = Guid.NewGuid();
            Template = uniqueCardName;
            Destination = collection;
        }
    }
}
