using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameState.EventObservers;
using dk.itu.game.msc.cgol.GameState.QueryHandlers;
using dk.itu.game.msc.cgol.State.QueryHandlers;

namespace dk.itu.game.msc.cgol.GameState
{
    public class GameStateSetup : IPluginSetup
    {
        private readonly Game game;
        private readonly Library library;
        private readonly CommandRepository generalCommands;
        private readonly CommandRepository stateCommands;
        private readonly ICommandRepositoryQueries commandComposite;

        public GameStateSetup()
        {
            game = new Game();
            library = new Library();
            generalCommands = new CommandRepository();
            stateCommands = new CommandRepository();
            commandComposite = new CommandComposite(generalCommands, stateCommands);
        }

        public void Setup(IPluginContext context)
        {
            var turnBasedRepository = new PlayerSpecificCommandRepository(context.Dispatcher, commandComposite);
            var recycleRules = new ReshuffleRules();
            
            // Query handlers
            context.Interpreter.AddConcept(new CardCounter(game));
            context.Interpreter.AddConcept(new TopCardGetter(game));
            context.Interpreter.AddConcept(new CardGetter(game));
            context.Interpreter.AddConcept(new TemplateGetter(library));
            context.Interpreter.AddConcept(new GetAvailableActionsHandler(turnBasedRepository));
            context.Interpreter.AddConcept(new GetCollectionNamesHandler(game));
            context.Interpreter.AddConcept(new GetVisibleCardsHandler(game));
            context.Interpreter.AddConcept(new GetCollectionTagsHandler(game));
            context.Interpreter.AddConcept(new GetAvailableActionsForCollectionHandler(turnBasedRepository, context.Dispatcher));
            context.Interpreter.AddConcept(new GetAvailableActionHandler(turnBasedRepository));
            context.Interpreter.AddConcept(new HasCardsHandler(game, context.Dispatcher));
            context.Interpreter.AddConcept(new GetCollectionContainingCardHandler(game));
            context.Interpreter.AddConcept(new CurrentPlayerHandler(game));
            context.Interpreter.AddConcept(new GetNumberOfPlayersHandler(game));
            context.Interpreter.AddConcept(new GetCollectionOwnerIndexHandler(game));
            context.Interpreter.AddConcept(new HasCollectionHandler(game));
            context.Interpreter.AddConcept(new CurrentStateHandler(game));
            context.Interpreter.AddConcept(new InStateHandler(game));
            context.Interpreter.AddConcept(new GetPlayersHandHandler(game));
            context.Interpreter.AddConcept(new GetCardsHandler(game));
            context.Interpreter.AddConcept(new GetCardSelectionHandler(game, context.Dispatcher));
            context.Interpreter.AddConcept(new GetReshuffleFromForHandler(recycleRules));
            context.Interpreter.AddConcept(new GetRandomCardHandler(game));

            // Event observers
            context.Interpreter.AddConcept(new CardCollectionDeclaredObserver(game));
            context.Interpreter.AddConcept(new HandDeclaredObserver(game));
            context.Interpreter.AddConcept(new CardAddedObserver(game));
            context.Interpreter.AddConcept(new CardDrawnObserver(game, context.Dispatcher));
            context.Interpreter.AddConcept(new CardMovedObserver(game));
            context.Interpreter.AddConcept(new CardDeclaredObserver(library));
            context.Interpreter.AddConcept(new CommandPostponedObserver(generalCommands));
            context.Interpreter.AddConcept(new InstantaniousEffectAddedToCardObserver(library));
            context.Interpreter.AddConcept(new PermanentEffectAddedToCardObserver(library));
            context.Interpreter.AddConcept(new PlayerDeclaredObserver(game));
            context.Interpreter.AddConcept(new CurrentPlayerSelectedObserver(game));
            context.Interpreter.AddConcept(new CardOwnerSetObserver(game));
            context.Interpreter.AddConcept(new CollectionOwnerSetObserver(game));
            context.Interpreter.AddConcept(new ZoneDeclaredObserver(game));
            context.Interpreter.AddConcept(new EnteredStateObserver(game));
            context.Interpreter.AddConcept(new TemporaryActionsClearedObserver(stateCommands));
            context.Interpreter.AddConcept(new CommandTemporarelyPostponedObserver(stateCommands));
            context.Interpreter.AddConcept(new CardDealtObserver(game, context.Dispatcher));
            context.Interpreter.AddConcept(new TagsAddedToTemplateObserver(library));
            context.Interpreter.AddConcept(new CollectionShuffledObserver(game));
            context.Interpreter.AddConcept(new CardsTransferredObserver(game));
            context.Interpreter.AddConcept(new ReshuffleRuleSetObserver(recycleRules));
            context.Interpreter.AddConcept(new CollectionRemovedObserver(game));
            context.Interpreter.AddConcept(new TagsAddedToCollectionObserver(game));
            context.Interpreter.AddConcept(new AcquisitionEffectAddedToCardObserver(library));
            context.Interpreter.AddConcept(new CurrentPlayersHandHandler(context.Dispatcher));
        }
    }
}

