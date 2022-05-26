using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class AddAcquisitionEffectToCard : ICommand
    {
        public Guid ProcessId => new Guid("6FA3C790-363F-4B9D-95F1-C183BF02D898");
        public Guid Instance { get; }
        public string UniqueCardName { get; }
        public ICommand Command { get; }
        
        [Concept(Description = "Adds a when drawn effect to a card. Use the when keyword together with the drawn trigger to utilize.")]
        public AddAcquisitionEffectToCard(string uniqueCardName, ICommand command)
        {
            Instance = Guid.NewGuid();
            UniqueCardName = uniqueCardName;
            Command = command;
        }
    }
}
