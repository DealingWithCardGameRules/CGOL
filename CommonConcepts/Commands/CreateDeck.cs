using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class CreateDeck : ICommand
    {
        public Guid ProcessId => new Guid("BB4E3338-8973-4D07-8892-983B3E617C95");

        public string Name { get; }
        public Guid Instance { get; }

        [Concept(Description = "Create a uniquely named deck of cards. Cards will be stacked on top of eachother and returned in a last in first out order.")]
        public CreateDeck(string uniqueName)
        {
            Instance = Guid.NewGuid();
            Name = uniqueName;
        }
    }
}
