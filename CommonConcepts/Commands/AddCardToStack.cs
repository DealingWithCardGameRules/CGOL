using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class AddCardToStack : ICommand
    {
        public Guid ProcessId => new Guid("C41ED5BD-D463-4B29-BD77-BCAB6FCF1853");
        public Guid StackId { get; }
        public ICard Card { get; }

        public AddCardToStack(Guid stackId, ICard card)
        {
            StackId = stackId;
            Card = card;
        }
    }
}
