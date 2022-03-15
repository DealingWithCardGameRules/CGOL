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

        public void Setup(IInterpolator interpolator)
        {
            // Command handlers
            interpolator.AddConcept(new PostponedCommandHandler(globalCommands));

            // Query handlers
            interpolator.AddConcept(new CardCounter(game));
            interpolator.AddConcept(new TopCardGetter(game));
            interpolator.AddConcept(new CardGetter(game));
            interpolator.AddConcept(new TemplateGetter(library));

            // Event observers
            interpolator.AddConcept(new CardStackDeclaredObserver(game));
            interpolator.AddConcept(new HandDeclaredObserver(game));
            interpolator.AddConcept(new CardAddedObserver(game));
            interpolator.AddConcept(new CardDrawnObserver(game));
            interpolator.AddConcept(new CardMovedObserver(game));
            interpolator.AddConcept(new CardDeclaredObserver(library));
        }
    }
}
