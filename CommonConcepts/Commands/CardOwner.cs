using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class CardOwner : ICommand
    {
        public Guid ProcessId => new Guid("5DDFB2E4-2176-447A-B359-E6FB06F86EDA");

        public Guid Instance { get; set; }
        public int PlayerIndex { get; }
        [AffectSelf] public Guid? CardId { get; set; }

        [Concept(Description = "Set the owner of a card to the player index.")]
        public CardOwner(int playerIndex, Guid? cardId)
        {
            Instance = Guid.NewGuid();
            PlayerIndex = playerIndex;
            CardId = cardId;
        }
    }
}
