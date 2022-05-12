using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PlayCard : ICommand
    {
        public Guid ProcessId => new Guid("AE58E7BB-29E7-41D6-882B-0AD6BA00F5E6");
        [PlayCollection] public string? Source { get; }
        public string? Destination { get; }
        [PlayCard] public Guid? Card { get; set; }
        public Guid Instance { get; }

        [Concept(Description = "Play a card from a collection. If from is not supplied, the current players hand is used. Can be supplied with a specific discard pile (which may be ignored if the card has a stated location). If not supplied, the card will be selected by the player based on the collection type.")]
        public PlayCard(string? from = null, string? discardTo = null, Guid? card = null)
        {
            Instance = Guid.NewGuid();
            Card = card;
            Source = from;
            Destination = discardTo;
        }
    }
}
