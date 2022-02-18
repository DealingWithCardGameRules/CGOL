using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetTopCard : IQuery<ICard>
    {
        public Guid Source { get; }

        public GetTopCard(Guid source)
        {
            Source = source;
        }
    }
}
