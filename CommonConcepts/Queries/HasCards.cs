using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class HasCards : IQuery<bool>
    {
        public string? Collection { get; }

        public HasCards(string collection = null)
        {
            Collection = collection;
        }
    }
}
