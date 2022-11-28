using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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

        public async Task Handle(AddCollectionTags command, IEventDispatcher eventDispatcher)
        {
            if (!await dispatcher.Dispatch(new HasCollection(command.Collection)))
                throw new Exception($"Collection does not exist, remember to create collection using {nameof(CreateDeck)}, {nameof(CreateHand)} or {nameof(CreateZone)}");

            await eventDispatcher.Dispatch(new TagsAddedToCollection(timeProvider.Now, command.ProcessId, command.Collection, command.Tags));
        }
    }
}
