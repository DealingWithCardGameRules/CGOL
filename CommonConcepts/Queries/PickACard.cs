using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class PickACard : IQuery<Guid?>
    {
        public string Collection { get; }
        public int Player { get; }
        public string[]? RequiredTags { get; }
        public int TimeoutLimitSeconds { get; set; } = 60;

        public PickACard(string collection, int player, string[]? requiredTags = null)
        {
            Collection = collection;
            Player = player;
            RequiredTags = requiredTags;
        }
    }
}
