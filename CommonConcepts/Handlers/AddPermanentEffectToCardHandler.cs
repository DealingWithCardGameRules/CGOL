using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class AddPermanentEffectToCardHandler : ICommandHandler<AddPermanentEffectToCard>
    {
        private readonly ITimeProvider provider;

        public AddPermanentEffectToCardHandler(ITimeProvider provider)
        {
            this.provider = provider ?? throw new System.ArgumentNullException(nameof(provider));
        }

        public void Handle(AddPermanentEffectToCard command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(
                new PermanentEffectAddedToCard(provider.Now, command.ProcessId, command.UniqueCardName, command.Command));
        }
    }
}
