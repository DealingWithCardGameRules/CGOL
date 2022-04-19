using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Handler;
using dk.itu.game.msc.cgdl.FluxxConcepts.Observers;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class FluxxConceptsSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            var drawCounter = new PlayerCounter();
            var playCounter = new PlayerCounter();

            // Command handlers
            context.Interpolator.AddConcept(new DrawCardHandler(context.Dispatcher, 100));
            context.Interpolator.AddConcept(new PlayCardHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new DrawLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new PlayLimitHandler(context.TimeProvider, context.Dispatcher));

            // Query handlers
            context.Interpolator.AddConcept(new DrawLimitReachedHandler(drawCounter));
            context.Interpolator.AddConcept(new GetDrawLimitHandler(drawCounter));
            context.Interpolator.AddConcept(new GetPlayLimitHandler(playCounter));

            // Event handler
            context.Interpolator.AddConcept(new CardDrawnCounter(drawCounter, context.Dispatcher));
            context.Interpolator.AddConcept(new DrawLimitSetObserver(drawCounter));
            context.Interpolator.AddConcept(new PlayLimitSetObserver(playCounter));
            context.Interpolator.AddConcept(new TurnStartedObserver(new[] { playCounter, drawCounter }, context.Dispatcher));
        }
    }
}
