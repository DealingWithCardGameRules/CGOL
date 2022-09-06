using dk.itu.game.msc.cgol.Common.Queries;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.State.QueryHandlers
{
    public class CurrentPlayersHandHandler : IQueryHandler<CurrentPlayersHand, string>
    {
        private readonly IQueryDispatcher dispatcher;

        public CurrentPlayersHandHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public string Handle(CurrentPlayersHand query)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer()) ?? throw new Exception("No current player found. Make sure players are setup.");
            return dispatcher.Dispatch(new GetPlayersHand(player.Index)) ?? throw new Exception("No player hand found. Make sure players are setup and assigned hands.");
        }
    }
}
