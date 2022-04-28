using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameState.EventObservers;
using dk.itu.game.msc.cgdl.GameState.QueryHandlers;

namespace dk.itu.game.msc.cgdl.GameState
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
            context.Interpolator.AddConcept(new CardCounter(game));
            context.Interpolator.AddConcept(new TopCardGetter(game));
            context.Interpolator.AddConcept(new CardGetter(game));
            context.Interpolator.AddConcept(new TemplateGetter(library));
            context.Interpolator.AddConcept(new GetAvailableActionsHandler(turnBasedRepository));
            context.Interpolator.AddConcept(new GetCollectionNamesHandler(game));
            context.Interpolator.AddConcept(new GetVisibleCardsHandler(game));
            context.Interpolator.AddConcept(new GetCollectionTagsHandler(game));
            context.Interpolator.AddConcept(new GetAvailableActionsForCollectionHandler(turnBasedRepository));
            context.Interpolator.AddConcept(new GetAvailableActionHandler(turnBasedRepository));
            context.Interpolator.AddConcept(new HasCardsHandler(game, context.Dispatcher));
            context.Interpolator.AddConcept(new GetCollectionContainingCardHandler(game));
            context.Interpolator.AddConcept(new CurrentPlayerHandler(game));
            context.Interpolator.AddConcept(new GetNumberOfPlayersHandler(game));
            context.Interpolator.AddConcept(new GetCollectionOwnerIndexHandler(game));
            context.Interpolator.AddConcept(new HasCollectionHandler(game));
            context.Interpolator.AddConcept(new CurrentStateHandler(game));
            context.Interpolator.AddConcept(new InStateHandler(game));
            context.Interpolator.AddConcept(new GetPlayersHandHandler(game));
            context.Interpolator.AddConcept(new GetCardsHandler(game));
            context.Interpolator.AddConcept(new GetReshuffleFromForHandler(recycleRules));
            context.Interpolator.AddConcept(new GetRandomCardHandler(game));

            // Event observers
            context.Interpolator.AddConcept(new CardCollectionDeclaredObserver(game));
            context.Interpolator.AddConcept(new HandDeclaredObserver(game));
            context.Interpolator.AddConcept(new CardAddedObserver(game));
            context.Interpolator.AddConcept(new CardDrawnObserver(game));
            context.Interpolator.AddConcept(new CardMovedObserver(game));
            context.Interpolator.AddConcept(new CardDeclaredObserver(library));
            context.Interpolator.AddConcept(new CommandPostponedObserver(generalCommands));
            context.Interpolator.AddConcept(new InstantaniousEffectAddedToCardObserver(library));
            context.Interpolator.AddConcept(new PermanentEffectAddedToCardObserver(library));
            context.Interpolator.AddConcept(new PlayerDeclaredObserver(game));
            context.Interpolator.AddConcept(new CurrentPlayerSelectedObserver(game));
            context.Interpolator.AddConcept(new CardOwnerSetObserver(game));
            context.Interpolator.AddConcept(new CollectionOwnerSetObserver(game));
            context.Interpolator.AddConcept(new ZoneDeclaredObserver(game));
            context.Interpolator.AddConcept(new EnteredStateObserver(game));
            context.Interpolator.AddConcept(new TemporaryActionsClearedObserver(stateCommands));
            context.Interpolator.AddConcept(new CommandTemporarelyPostponedObserver(stateCommands));
            context.Interpolator.AddConcept(new CardDealtObserver(game));
            context.Interpolator.AddConcept(new TagsAddedToTemplateObserver(library));
            context.Interpolator.AddConcept(new CollectionShuffledObserver(game));
            context.Interpolator.AddConcept(new CardsTransferredObserver(game));
            context.Interpolator.AddConcept(new ReshuffleRuleSetObserver(recycleRules));
            context.Interpolator.AddConcept(new CollectionRemovedObserver(game));
            context.Interpolator.AddConcept(new TagsAddedToCollectionObserver(game));
        }
    }
}

