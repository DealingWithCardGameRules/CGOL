using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetCollectionContainingCard : IQuery<string?>
    {
        public Guid CardId { get; }

        [Concept(Description = "Try to get the name of a collection containing a specific card.")]
        public GetCollectionContainingCard(Guid cardId)
        {
            CardId = cardId;
        }
    }
}
