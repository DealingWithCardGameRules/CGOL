using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class DealAllHandler : ICommandHandler<DealAll>
    {
        private readonly IDispatcher dispatcher;

        public DealAllHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DealAll command, IEventDispatcher eventDispatcher)
        {
            var players = dispatcher.Dispatch(new GetNumberOfPlayers());
            for (int i = 0; i < players; i++)
            {
                var hand = dispatcher.Dispatch(new GetPlayersHand(i+1));
                if (hand != null)
                    dispatcher.Dispatch(new DealCard(command.Source, hand, command.Cards));
            }
        }
    }
}
