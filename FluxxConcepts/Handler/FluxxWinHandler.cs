using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class FluxxWinHandler : ICommandHandler<Win>
    {
        private readonly ICommandHandler<Win> decoratee;
        private readonly IDispatcher dispatcher;

        public FluxxWinHandler(ICommandHandler<Win> decoratee, IDispatcher dispatcher)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(Win command, IEventDispatcher eventDispatcher)
        {
            var playerIndex = command.PlayerIndex ?? dispatcher.Dispatch(new CurrentPlayer())?.Index;
            if (playerIndex == null)
                throw new Exception("No winner specified and no current player.");
            var creeperZone = dispatcher.Dispatch(new GetCollectionNames { OwnedBy = playerIndex, WithTags = new[] { "zone", "creepers" } }).FirstOrDefault();

            if (creeperZone == null || dispatcher.Dispatch(new CardCount(creeperZone)) == 0)
                decoratee.Handle(command, eventDispatcher);
        }
    }
}
