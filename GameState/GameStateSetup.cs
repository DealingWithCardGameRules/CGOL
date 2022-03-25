using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameState.CommandHandlers;
using dk.itu.game.msc.cgdl.GameState.EventObservers;
using dk.itu.game.msc.cgdl.GameState.QueryHandlers;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class GameStateSetup : IPluginSetup
    {
        Game game;
        Library library;
        CommandRepository globalCommands;

        public GameStateSetup()
        {
            game = new Game();
            library = new Library();
            globalCommands = new CommandRepository();
        }

        public void Setup(IPluginContext context)
        {
            // Query handlers
            context.Interpolator.AddConcept(new CardCounter(game));
            context.Interpolator.AddConcept(new TopCardGetter(game));
            context.Interpolator.AddConcept(new CardGetter(game));
            context.Interpolator.AddConcept(new TemplateGetter(library));
            context.Interpolator.AddConcept(new GetAvailableActionsHandler(globalCommands));
            context.Interpolator.AddConcept(new GetCollectionNamesHandler(game));
            context.Interpolator.AddConcept(new GetVisibleCardsHandler(game));
            context.Interpolator.AddConcept(new GetCollectionTagsHandler(game));
            context.Interpolator.AddConcept(new GetAvailableActionsForCollectionHandler(globalCommands));
            context.Interpolator.AddConcept(new GetAvailableActionHandler(globalCommands));
            context.Interpolator.AddConcept(new HasCardsHandler(game));

            // Event observers
            context.Interpolator.AddConcept(new CardStackDeclaredObserver(game));
            context.Interpolator.AddConcept(new HandDeclaredObserver(game));
            context.Interpolator.AddConcept(new CardAddedObserver(game));
            context.Interpolator.AddConcept(new CardDrawnObserver(game));
            context.Interpolator.AddConcept(new CardMovedObserver(game));
            context.Interpolator.AddConcept(new CardDeclaredObserver(library));
            context.Interpolator.AddConcept(new CommandPostponedObserver(globalCommands));
            context.Interpolator.AddConcept(new InstantaniousEffectAddedToCardObserver(library));
        }
    }
}
