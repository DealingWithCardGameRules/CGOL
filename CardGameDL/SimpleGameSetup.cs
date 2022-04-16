﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;

namespace dk.itu.game.msc.cgdl
{
    public class SimpleGameSetup
    {
        private readonly IInterpolator interpolator;
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimpleGameSetup(IInterpolator interpolator, ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.interpolator = interpolator;
            this.timeProvider = timeProvider;
            this.dispatcher = dispatcher;
        }

        public void AddHandlers()
        {
            // Command handlers
            interpolator.AddConcept(new SimplyDeclareCollection(timeProvider));
            interpolator.AddConcept(new SimplyDeclareHand(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyAddCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDrawCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDealCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyRevealAndMove(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDeclareCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyPlaceInCollection(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDeclarePlayers(timeProvider));
            interpolator.AddConcept(new DiscardCardHandler(dispatcher));
            interpolator.AddConcept(new CardOwnerHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new CollectionOwnerHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDeclareZone(timeProvider));
            interpolator.AddConcept(new SimplyChangeState(timeProvider, dispatcher));
            interpolator.AddConcept(new ResolvePermanentsHandler(dispatcher));
            interpolator.AddConcept(new ClearTemporaryActionsHandler(timeProvider));
            interpolator.AddConcept(new SimplyExecuteCommandBundle(dispatcher));
            interpolator.AddConcept(new AllDrawHandler(dispatcher));
        }
    }
}
