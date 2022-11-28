using dk.itu.game.msc.cgol.Common.Queries;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.State.QueryHandlers
{
    public class CurrentPlayersHandHandler : IQueryHandler<CurrentPlayersHand, string>
    {
        private readonly IQueryDispatcher dispatcher;

        public CurrentPlayersHandHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task<string> Handle(CurrentPlayersHand query)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer()) ?? throw new Exception("No current player found. Make sure players are setup.");
            return await dispatcher.Dispatch(new GetPlayersHand(player.Index)) ?? throw new Exception("No player hand found. Make sure players are setup and assigned hands.");
        }
    }
}
