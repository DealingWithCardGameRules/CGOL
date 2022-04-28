using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class AddAcquisitionEffectToCard : ICommand
    {
        public Guid ProcessId => new Guid("6FA3C790-363F-4B9D-95F1-C183BF02D898");
        public Guid Instance { get; }
        public string UniqueCardName { get; }
        public ICommand Command { get; }

        public AddAcquisitionEffectToCard(string uniqueCardName, ICommand command)
        {
            Instance = Guid.NewGuid();
            UniqueCardName = uniqueCardName;
            Command = command;
        }
    }
}
