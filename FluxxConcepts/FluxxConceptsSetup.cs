using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Handler;
using dk.itu.game.msc.cgdl.FluxxConcepts.Observers;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class FluxxConceptsSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            var drawCounter = new DrawCounter();

            // Command handlers
            context.Interpolator.AddConcept(new DrawCardHandler(context.Dispatcher, 100));
            context.Interpolator.AddConcept(new PlayCardHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new DrawLimitHandler(context.TimeProvider, context.Dispatcher));

            // Query handlers
            context.Interpolator.AddConcept(new DrawLimitReachedHandler(drawCounter));
            context.Interpolator.AddConcept(new GetDrawLimitHandler(drawCounter));

            // Event handler
            context.Interpolator.AddConcept(new CardDrawnCounter(drawCounter, context.Dispatcher));
            context.Interpolator.AddConcept(new DrawLimitSetObserver(drawCounter));
        }
    }
}
