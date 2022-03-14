﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;
using dk.itu.game.msc.cgdl.GameState;
using dk.itu.game.msc.cgdl.GameState.EventObservers;
using dk.itu.game.msc.cgdl.GameState.QueryHandlers;

namespace dk.itu.game.msc.cgdl
{
    public class SimpleGameSetup
    {
        private readonly Game game;
        private readonly IInterpolator interpolator;
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;
        private readonly Library library;

        public SimpleGameSetup(Game game, IInterpolator interpolator, ITimeProvider timeProvider, IDispatcher dispatcher, Library library)
        {
            this.game = game;
            this.interpolator = interpolator;
            this.timeProvider = timeProvider;
            this.dispatcher = dispatcher;
            this.library = library;
        }

        public void AddHandlers()
        {
            // Command handlers
            interpolator.AddConcept(new SimplyDeclareCollection(timeProvider));
            interpolator.AddConcept(new SimplyDeclareHand(timeProvider));
            interpolator.AddConcept(new SimplyAddCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDrawCard(timeProvider));
            interpolator.AddConcept(new SimplyRevealAndMove(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDeclareCard(timeProvider));

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
