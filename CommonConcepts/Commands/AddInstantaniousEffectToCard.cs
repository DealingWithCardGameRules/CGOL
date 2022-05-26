using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class AddInstantaniousEffectToCard : ICommand
    {
        public Guid ProcessId => new Guid("72A0A02C-3CD3-492D-82CF-B3ACDD05B8D7");
        public Guid Instance { get; private set; }
        public string UniqueCardName { get; }
        public ICommand Command { get; }

        [Concept(Description = "Adds a when played effect to a card. Use the when keyword together with the played trigger to utilize.")]
        public AddInstantaniousEffectToCard(string uniqueCardName, ICommand command)
        {
            Instance = Guid.NewGuid();
            UniqueCardName = uniqueCardName;
            Command = command;
        }
    }
}
