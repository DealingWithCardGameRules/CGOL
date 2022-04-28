using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class ResolveAcquisitionEffectsHandler : ICommandHandler<ResolveAcquisitionEffects>
    {
        private readonly IDispatcher dispatcher;

        public ResolveAcquisitionEffectsHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(ResolveAcquisitionEffects command, IEventDispatcher eventDispatcher)
        {
            var template = dispatcher.Dispatch(new GetTemplate(command.Card.Template));
            if (template == null)
                return; // No acquisition effects to resolve

            foreach (ICommand effect in template.Acquisition)
            {
                effect.SetAffactSelfRef(command.Card.Instance);
                dispatcher.Dispatch(effect);
            }
        }
    }
}
