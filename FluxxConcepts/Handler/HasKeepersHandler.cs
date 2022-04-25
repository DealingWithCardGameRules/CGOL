using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class HasKeepersHandler : IQueryHandler<HasKeepers, bool>
    {
        private readonly IQueryDispatcher dispatcher;

        public HasKeepersHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public bool Handle(HasKeepers query)
        {
            var collection = query.Collection ?? GetPlayersKeepersZone();
            if (collection == null)
                throw new Exception("No collection stated and no keepers zone for the current player. Please state collection manually or assign a keepers zone to the player.");
            var cards = dispatcher.Dispatch(new GetCards(collection));
            
            foreach (var keeper in query.Keepers)
            {
                var required = query.Keepers.Count(k => k.Equals(keeper));
                var found = cards.Count(c => c.Template.Equals(keeper));
                if (found < required)
                    return false;
            }
            return true;
        }

        private string? GetPlayersKeepersZone()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                return null;

            var getCollectionNames = new GetCollectionNames()
            {
                OwnedBy = player.Index,
                WithTags = new[] { "keepers" }
            };
            var names = dispatcher.Dispatch(getCollectionNames);
            return names.SingleOrDefault();
        }
    }
}
