using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;
using dk.itu.game.msc.cgdl.GameState;
using dk.itu.game.msc.cgdl.GameState.EventObservers;
using dk.itu.game.msc.cgdl.GameState.QueryHandlers;

namespace dk.itu.game.msc.cgdl
{
    public class GDLSetup
    {
        private readonly Game game;
        private readonly Interpolator interpolator;
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public GDLSetup(Game game, Interpolator interpolator, ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.game = game;
            this.interpolator = interpolator;
            this.timeProvider = timeProvider;
            this.dispatcher = dispatcher;
        }

        public void AddHandlers()
        {
            // Command handlers
            interpolator.AddConcept(new SimplyDeclareStack(timeProvider));
            interpolator.AddConcept(new SimplyDeclareHand(timeProvider));
            interpolator.AddConcept(new SimplyAddCard(timeProvider));
            interpolator.AddConcept(new SimplyDrawCard(timeProvider));
            interpolator.AddConcept(new SimplyRevealAndMove(timeProvider, dispatcher));

            // Query handlers
            interpolator.AddConcept(new CardCounter(game));
            interpolator.AddConcept(new TopCardGetter(game));
            interpolator.AddConcept(new CardGetter(game));

            // Event observers
            interpolator.AddConcept(new CardStackDeclaredObserver(game));
            interpolator.AddConcept(new HandDeclaredObserver(game));
            interpolator.AddConcept(new CardAddedObserver(game));
            interpolator.AddConcept(new CardDrawnObserver(game));
            interpolator.AddConcept(new CardMovedObserver(game));
        }
    }
}
