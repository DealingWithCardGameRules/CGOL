using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCollectionContainingCard : IQuery<string?>
    {
        public Guid CardId { get; }

        public GetCollectionContainingCard(Guid cardId)
        {
            CardId = cardId;
        }
    }
}
