using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class OnlyHasKeepersHandler : IQueryHandler<OnlyHasKeepers, bool>
    {
        private readonly IQueryDispatcher dispatcher;

        public OnlyHasKeepersHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public bool Handle(OnlyHasKeepers query)
        {
            var collection = query.Collection ?? GetPlayersKeepersZone();
            if (collection == null)
                throw new Exception("No collection stated and no keepers zone for the current player. Please state collection manually or assign a keepers zone to the player.");
            var cards = dispatcher.Dispatch(new GetCards(collection));
            if (cards.Count() != query.Keepers.Count())
                return false; // Should have the exact same amount

            var TotalFound = 0;
            foreach (var keeper in query.Keepers)
            {
                var required = query.Keepers.Count(k => k.Equals(keeper));
                var found = cards.Count(c => c.Template.Equals(keeper));
                
                if (found < required)
                    return false;
                else
                    TotalFound++;
            }
            return TotalFound == query.Keepers.Count();
        }

        private string? GetPlayersKeepersZone()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                return null;

            var getCollectionNames = new GetCollectionNames()
            {
                OwnedBy = player.Index,
                WithTags = new[] { "zone", "keepers" }
            };
            var names = dispatcher.Dispatch(getCollectionNames);
            return names.SingleOrDefault();
        }
    }
}
