using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class AddPermanentEffectToCard : ICommand
    {
        public Guid ProcessId => new Guid("72A0A02C-3CD3-492D-82CF-B3ACDD05B8D7");
        public Guid Instance { get; private set; }
        public string UniqueCardName { get; }
        public ICommand Command { get; }
        public AddPermanentEffectToCard(string uniqueCardName, ICommand command)
        {
            Instance = Guid.NewGuid();
            UniqueCardName = uniqueCardName;
            Command = command;
        }
    }
}
