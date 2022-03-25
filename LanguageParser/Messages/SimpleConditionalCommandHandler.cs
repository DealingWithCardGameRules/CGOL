﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;

namespace dk.itu.game.msc.cgdl.LanguageParser.Messages
{
    public class SimpleConditionalCommandHandler : ICommandHandler<ConditionalCommand>
    {
        private readonly IDispatcher dispatcher;

        public SimpleConditionalCommandHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(ConditionalCommand command, IEventDispatcher eventDispatcher)
        {
            if (dispatcher.Dispatch(command.Query))
                dispatcher.Dispatch(command.Command);
        }
    }
}