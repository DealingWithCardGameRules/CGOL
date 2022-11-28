using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
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

        public async Task Handle(Win command, IEventDispatcher eventDispatcher)
        {
            var playerIndex = command.PlayerIndex ?? (await dispatcher.Dispatch(new CurrentPlayer()))?.Index;
            if (playerIndex == null)
                throw new Exception("No winner specified and no current player.");
            var creeperZone = await (await dispatcher.Dispatch(new GetCollectionNames { OwnedBy = playerIndex, WithTags = new[] { "zone", "creepers" } }))().FirstOrDefaultAsync();

            if (creeperZone == null || await dispatcher.Dispatch(new CardCount(creeperZone)) == 0)
                await decoratee.Handle(command, eventDispatcher);
        }
    }
}
