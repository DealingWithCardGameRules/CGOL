using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class AddCardTagsHandler : ICommandHandler<AddCardTags>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public AddCardTagsHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(AddCardTags command, IEventDispatcher eventDispatcher)
        {
            if (dispatcher.Dispatch(new GetTemplate(command.Card)) == null)
                throw new Exception($"Card template name does not exist, remember to create card using {nameof(CreateCard)}");

            eventDispatcher.Dispatch(new TagsAddedToTemplate(timeProvider.Now, command.ProcessId, command.Card, command.Tags));
        }
    }
}
