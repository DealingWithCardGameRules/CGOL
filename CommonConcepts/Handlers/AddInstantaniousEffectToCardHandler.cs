using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class AddInstantaniousEffectToCardHandler : ICommandHandler<AddInstantaniousEffectToCard>
    {
        private readonly ITimeProvider provider;

        public AddInstantaniousEffectToCardHandler(ITimeProvider provider)
        {
            this.provider = provider ?? throw new System.ArgumentNullException(nameof(provider));
        }

        public void Handle(AddInstantaniousEffectToCard command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(
                new InstantaniousEffectAddedToCard(provider.Now, command.ProcessId, command.UniqueCardName, command.Command));
        }
    }
}
