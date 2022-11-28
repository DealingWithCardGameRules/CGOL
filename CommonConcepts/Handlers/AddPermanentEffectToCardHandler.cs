using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class AddPermanentEffectToCardHandler : ICommandHandler<AddPermanentEffectToCard>
    {
        private readonly ITimeProvider provider;

        public AddPermanentEffectToCardHandler(ITimeProvider provider)
        {
            this.provider = provider ?? throw new System.ArgumentNullException(nameof(provider));
        }

        public async Task Handle(AddPermanentEffectToCard command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(
                new PermanentEffectAddedToCard(provider.Now, command.ProcessId, command.UniqueCardName, command.Command));
        }
    }
}
