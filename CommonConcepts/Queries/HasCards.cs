using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class HasCards : IQuery<bool>
    {
        public Guid Source { get; }

        public HasCards(Guid source)
        {
            Source = source;
        }
    }
}
