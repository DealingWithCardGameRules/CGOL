using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyDeclareHand : ICommandHandler<CreateHand>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyDeclareHand(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(CreateHand command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(new HandDeclared(timeProvider.Now, command.ProcessId, command.Hand));
            if (command.PlayerIndex.HasValue)
                await dispatcher.Dispatch(new CollectionOwner(command.Hand, command.PlayerIndex.Value));
        }
    }
}
