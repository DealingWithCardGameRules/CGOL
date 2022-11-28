using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class ResolveAcquisitionEffectsHandler : ICommandHandler<ResolveAcquisitionEffects>
    {
        private readonly IDispatcher dispatcher;

        public ResolveAcquisitionEffectsHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(ResolveAcquisitionEffects command, IEventDispatcher eventDispatcher)
        {
            var template = await dispatcher.Dispatch(new GetTemplate(command.Card.Template));
            if (template == null)
                return; // No acquisition effects to resolve

            foreach (ICommand effect in template.Acquisition)
            {
                effect.SetAffactSelfRef(command.Card.Instance);
                await dispatcher.Dispatch(effect);
            }
        }
    }
}
