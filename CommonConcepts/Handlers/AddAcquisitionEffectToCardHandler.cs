using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class AddAcquisitionEffectToCardHandler : ICommandHandler<AddAcquisitionEffectToCard>
    {
        private readonly ITimeProvider timeProvider;

        public AddAcquisitionEffectToCardHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public async Task Handle(AddAcquisitionEffectToCard command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(
                new AcquisitionEffectAddedToCard(timeProvider.Now, command.ProcessId, command.UniqueCardName, command.Command));
        }
    }
}
