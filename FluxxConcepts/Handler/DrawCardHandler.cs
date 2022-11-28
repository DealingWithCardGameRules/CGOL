using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public sealed class DrawCardHandler : ICommandHandler<DrawCard>
    {
        private readonly ICommandHandler<DrawCard> decoratee;
        private readonly IDispatcher dispatcher;

        public DrawCardHandler(ICommandHandler<DrawCard> decoratee, IDispatcher dispatcher)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to setup players.");
            
            if (!await dispatcher.Dispatch(new DrawLimitReached(player.Index)))
            {
                await decoratee.Handle(command, eventDispatcher);
                await dispatcher.Dispatch(new ClaimOwnership());
            }
        }
    }
}
