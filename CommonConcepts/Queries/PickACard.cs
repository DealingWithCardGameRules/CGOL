using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class PickACard : IQuery<Guid?>
    {
        public string Collection { get; }
        public int Player { get; }
        public string[]? RequiredTags { get; }
        public bool Required { get; }
        public int TimeoutLimitSeconds { get; set; } = 300; // Five minutes

        public PickACard(string collection, int player, string[]? requiredTags = null, bool required = true)
        {
            Collection = collection;
            Player = player;
            RequiredTags = requiredTags;
            Required = required;
        }
    }
}
