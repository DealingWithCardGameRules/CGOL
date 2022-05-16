using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetTopCard : IQuery<ICard?>
    {
        public string Collection { get; }

        public GetTopCard(string collection)
        {
            Collection = collection;
        }
    }
}
