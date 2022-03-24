using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Handler;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class FluxxConceptsSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            var drawCounter = new DrawCounter();

            // Command handlers
            context.Interpolator.AddConcept(new DrawCardHandler(context.Dispatcher, 100));
            
            // Query handlers
            context.Interpolator.AddConcept(new CurrentPlayerHandler());
            context.Interpolator.AddConcept(new DrawLimitReachedHandler(drawCounter));

            // Event handler
            context.Interpolator.AddConcept(new CardDrawnCounter(drawCounter, context.Dispatcher));
        }
    }
}
