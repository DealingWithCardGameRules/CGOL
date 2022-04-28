using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Handler;
using dk.itu.game.msc.cgdl.FluxxConcepts.Observers;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class FluxxConceptsSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            var drawCounter = new PlayerCounter();
            var playCounter = new PlayerCounter();
            var keeperCounter = new KeeperCounter(context.Dispatcher);

            // Command handlers
            context.Interpolator.AddConcept(new DrawCardHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new PlayCardHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new DrawLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new PlayLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new OwnerOfWinsHandler(context.Dispatcher));
            context.Interpolator.AddConcept(new OwnerOfWinsExclusiveHandler(context.Dispatcher));
            context.Interpolator.AddConcept(new HandLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new KeeperLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpolator.AddConcept(new FluxxWinHandler(context.Interpolator.GetService<ICommandHandler<Win>>(), context.Dispatcher));

            // Query handlers
            context.Interpolator.AddConcept(new DrawLimitReachedHandler(drawCounter));
            context.Interpolator.AddConcept(new GetDrawLimitHandler(drawCounter));
            context.Interpolator.AddConcept(new GetPlayLimitHandler(playCounter));
            context.Interpolator.AddConcept(new PlayLimitReachedHandler(playCounter));
            context.Interpolator.AddConcept(new HasKeepersHandler(context.Dispatcher));
            context.Interpolator.AddConcept(new OnlyHasKeepersHandler(context.Dispatcher));
            context.Interpolator.AddConcept(new MostKeepersHandler(keeperCounter));
            context.Interpolator.AddConcept(new FewestKeepersHandler(keeperCounter));
            context.Interpolator.AddConcept(new PlayLimitAboveHandler(context.Dispatcher));

            // Event handler
            context.Interpolator.AddConcept(new CardDrawnCounter(drawCounter, context.Dispatcher));
            context.Interpolator.AddConcept(new DrawLimitSetObserver(drawCounter));
            context.Interpolator.AddConcept(new PlayLimitSetObserver(playCounter));
            context.Interpolator.AddConcept(new TurnStartedObserver(context.Dispatcher, playCounter, drawCounter));
            context.Interpolator.AddConcept(new CardResolvedObserver(playCounter, context.Dispatcher));
        }
    }
}
