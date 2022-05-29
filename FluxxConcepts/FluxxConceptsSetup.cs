using dk.itu.game.msc.cgol.FluxxConcepts.Handler;
using dk.itu.game.msc.cgol.FluxxConcepts.Observers;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts
{
    public class FluxxConceptsSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            var drawCounter = new PlayerCounter();
            var playCounter = new PlayerCounter();
            var cardCounter = new CardCounter(context.Dispatcher);

            // Command handlers
            context.Interpreter.AddConcept(new DrawCardHandler(context.Interpreter.GetService<ICommandHandler<DrawCard>>(), context.Dispatcher));
            context.Interpreter.AddConcept(new PlayCardHandler(context.Interpreter.GetService<ICommandHandler<PlayCard>>(), context.Dispatcher));
            context.Interpreter.AddConcept(new DrawLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpreter.AddConcept(new PlayLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpreter.AddConcept(new OwnerOfWinsHandler(context.Dispatcher));
            context.Interpreter.AddConcept(new OwnerOfWinsExclusiveHandler(context.Dispatcher));
            context.Interpreter.AddConcept(new HandLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpreter.AddConcept(new KeeperLimitHandler(context.TimeProvider, context.Dispatcher));
            context.Interpreter.AddConcept(new FluxxWinHandler(context.Interpreter.GetService<ICommandHandler<Win>>(), context.Dispatcher));
            context.Interpreter.AddConcept(new MostCardsWinsHandler(cardCounter, context.Dispatcher));
            context.Interpreter.AddConcept(new RefreshHandHandler(context.Dispatcher));

            // Query handlers
            context.Interpreter.AddConcept(new DrawLimitReachedHandler(drawCounter));
            context.Interpreter.AddConcept(new GetDrawLimitHandler(drawCounter));
            context.Interpreter.AddConcept(new GetPlayLimitHandler(playCounter));
            context.Interpreter.AddConcept(new PlayLimitReachedHandler(playCounter));
            context.Interpreter.AddConcept(new HasKeepersHandler(context.Dispatcher));
            context.Interpreter.AddConcept(new OnlyHasKeepersHandler(context.Dispatcher));
            context.Interpreter.AddConcept(new MostKeepersHandler(cardCounter));
            context.Interpreter.AddConcept(new FewestKeepersHandler(cardCounter));
            context.Interpreter.AddConcept(new PlayLimitAboveHandler(context.Dispatcher));

            // Event handler
            context.Interpreter.AddConcept(new CardDrawnCounter(drawCounter, context.Dispatcher));
            context.Interpreter.AddConcept(new DrawLimitSetObserver(drawCounter));
            context.Interpreter.AddConcept(new PlayLimitSetObserver(playCounter));
            context.Interpreter.AddConcept(new TurnStartedObserver(context.Dispatcher, playCounter, drawCounter));
            context.Interpreter.AddConcept(new CardResolvedObserver(playCounter));
        }
    }
}
