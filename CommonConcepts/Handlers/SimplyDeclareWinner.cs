﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareWinner : ICommandHandler<Win>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IQueryDispatcher dispatcher;

        public SimplyDeclareWinner(ITimeProvider timeProvider, IQueryDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(Win command, IEventDispatcher eventDispatcher)
        {
            var playerIndex = command.PlayerIndex ?? dispatcher.Dispatch(new CurrentPlayer())?.Index;
            eventDispatcher.Dispatch(new PlayerWon(timeProvider.Now, command.ProcessId, playerIndex));
        }
    }
}