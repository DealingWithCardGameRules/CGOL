using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.Common.Queries;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class PlayCard : ICommand
    {
        public Guid ProcessId => new Guid("AE58E7BB-29E7-41D6-882B-0AD6BA00F5E6");
        [PlayCollection] public MaybeQuery<string> Source { get; }

        public string? Destination { get; }
        [PlayCard] public MaybeChoice<Guid> Card { get; set; }
        public Guid Instance { get; }

        [Concept(Description = "Play a card from a collection. If from is not supplied, the current players hand is used. Can be supplied with a specific discard pile (which may be ignored if the card has a stated location). If not supplied, the card will be selected by the player based on the collection type.")]
        public PlayCard(string? from = null, string? discardTo = null, Guid? card = null)
        {
            Instance = Guid.NewGuid();
            Source = (from != null) ? new MaybeQuery<string>(from) : new MaybeQuery<string>(new CurrentPlayersHand());
            Card = (card.HasValue) ? new MaybeChoice<Guid>(card.Value) : new MaybeChoice<Guid>(new GetCardSelection(Source));
            Destination = discardTo;
        }
    }
}
