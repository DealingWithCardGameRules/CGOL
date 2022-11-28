using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class DealAllHandler : ICommandHandler<DealAll>
    {
        private readonly IDispatcher dispatcher;

        public DealAllHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(DealAll command, IEventDispatcher eventDispatcher)
        {
            var players = await dispatcher.Dispatch(new GetNumberOfPlayers());
            for (int i = 0; i < players; i++)
            {
                var hand = await dispatcher.Dispatch(new GetPlayersHand(i+1));
                if (hand != null)
                    await dispatcher.Dispatch(new DealCard(command.Source, command.Cards, hand));
            }
        }
    }
}
