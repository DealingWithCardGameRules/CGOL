using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class AddAcquisitionEffectToCardHandler : ICommandHandler<AddAcquisitionEffectToCard>
    {
        private readonly ITimeProvider timeProvider;

        public AddAcquisitionEffectToCardHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(AddAcquisitionEffectToCard command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(
                new AcquisitionEffectAddedToCard(timeProvider.Now, command.ProcessId, command.UniqueCardName, command.Command));
        }
    }
}
