﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class OwnerOfWinsExclusiveHandler : ICommandHandler<OwnerOfWinsExclusive>
    {
        private readonly IDispatcher dispatcher;

        public OwnerOfWinsExclusiveHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(OwnerOfWinsExclusive command, IEventDispatcher eventDispatcher)
        {
            var zones = dispatcher.Dispatch(new GetCollectionNames { WithTags = new[] { "zone", "keepers" } });
            var keepers = string.Join(",", command.Keepers);

            foreach (var zone in zones)
            {
                if (dispatcher.Dispatch(new OnlyHasKeepers(keepers, zone)))
                {
                    var owner = dispatcher.Dispatch(new GetCollectionOwnerIndex(zone));
                    if (owner.HasValue)
                        dispatcher.Dispatch(new Win(owner.Value));
                }
            }
        }
    }
}