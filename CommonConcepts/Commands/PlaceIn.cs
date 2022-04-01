using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PlaceIn : ICommand
    {
        public Guid ProcessId => new Guid("ABD223A3-0FFC-4CF5-94C2-5FF2E222B76F");
        public Guid Instance { get; }
        public string Collection { get; }

        // Will be overwritten when resolving instantanious/permanent effects.
        [AffectSelf] public Guid? CardId { get; set; }

        public PlaceIn(string collection, Guid? cardId = null)
        {
            Instance = Guid.NewGuid();
            Collection = collection;
            CardId = cardId;
        }
    }
}
