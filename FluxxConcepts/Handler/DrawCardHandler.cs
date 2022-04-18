using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public sealed class DrawCardHandler : ICommandHandler<DrawCard>
    {
        private readonly IQueryDispatcher dispatcher;
        private readonly int maxiumDraws; // Should always have a hard limit

        public DrawCardHandler(IQueryDispatcher dispatcher, int maxiumDraws)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            this.maxiumDraws = maxiumDraws;
        }

        public void Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to setup players.");

            var destination = command.Destination ?? dispatcher.Dispatch(new GetPlayersHand(player.Index));
            if (destination == null)
                throw new ArgumentNullException($"No destination found, please specify one by filling out the \"to\" parameter or make sure the current player has a hand.");

            for (var i = 0; i < maxiumDraws; i++)
            {
                if (!dispatcher.Dispatch(new HasCards(command.Source)))
                    return;

                if (dispatcher.Dispatch(new DrawLimitReached(player.Identity)))
                    return;
                
                eventDispatcher.Dispatch(new CardDrawn(DateTime.Now, command.ProcessId, command.Source, destination));
            }
        }
    }
}
