﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareZone : ICommandHandler<CreateZone>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareZone(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(CreateZone command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new ZoneDeclared(timeProvider.Now, command.ProcessId, command.Name, command.PlayerIndex));
        }
    }
}
