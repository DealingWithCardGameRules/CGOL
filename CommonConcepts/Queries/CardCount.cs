using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class CardCount : IQuery<int>
    {
        public string Collection { get; }

        public CardCount(string collection)
        {
            Collection = collection;
        }
    }
}
