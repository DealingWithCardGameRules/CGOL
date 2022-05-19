using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
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

        [Concept(Description = "Try to get a given player  to pick a card from a specific collection. The selection can be limited to certain tags.")]
        public PickACard(string collection, int player, string[]? requiredTags = null, bool required = true)
        {
            Collection = collection;
            Player = player;
            RequiredTags = requiredTags;
            Required = required;
        }
    }
}
