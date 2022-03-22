using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CreateCard : ICommand
    {
        public Guid ProcessId => new Guid("DE353A49-5525-4366-9D07-6FBB96F33DFA");

        public string Template { get; }

        public Guid Instance { get; }

        public CreateCard(string uniqueCardName)
        {
            Instance = Guid.NewGuid();
            Template = uniqueCardName;
        }
    }
}
