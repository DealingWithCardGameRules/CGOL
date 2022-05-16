using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Collections.Generic;
using System.Text;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class AddCollectionTagsHandler : ICommandHandler<AddCollectionTags>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public AddCollectionTagsHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(AddCollectionTags command, IEventDispatcher eventDispatcher)
        {
            if (!dispatcher.Dispatch(new HasCollection(command.Collection)))
                throw new Exception($"Collection does not exist, remember to create collection using {nameof(CreateDeck)}, {nameof(CreateHand)} or {nameof(CreateZone)}");

            eventDispatcher.Dispatch(new TagsAddedToCollection(timeProvider.Now, command.ProcessId, command.Collection, command.Tags));
        }
    }
}
