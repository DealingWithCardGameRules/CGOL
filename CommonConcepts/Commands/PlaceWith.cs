using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PlaceWith : ICommand
    {
        public Guid ProcessId => new Guid("8D57D37E-60EE-4A79-BC8F-8AAD550DA521");
        public Guid Instance { get; }

        // Will be overwritten when resolving instantanious/permanent effects.
        [AffectSelf] public Guid? CardId { get; set; }

        public IEnumerable<string> Tags { get; }

        [Concept(Description = "Place a card in a collection with certain tags and owned by the current player. When attached to a card template, the card will automatically be filled out with the instance of that card template.")]
        public PlaceWith(string tags, Guid? cardId = null)
        {
            Instance = Guid.NewGuid();
            CardId = cardId;
            Tags = tags.CommaSeperateTrimmed();
        }
    }
}
