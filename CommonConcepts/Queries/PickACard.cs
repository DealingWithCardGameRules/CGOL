using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class PickACard : IQuery<Guid?>
    {
        public string Collection { get; }
        public ICard[] Selection { get; }
        public int Player { get; }
        public bool Required { get; }
        public int TimeoutLimitSeconds { get; set; } = 300; // Five minutes

        [Concept(Description = "Try to get a given player to pick one in a selection of cards.")]
        public PickACard(IEnumerable<ICard> selection, int player, bool required = true)
        {
            Selection = selection.ToArray();
            Player = player;
            Required = required;
        }
    }
}
