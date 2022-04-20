﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public class CommonConceptsSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            var interpolator = context.Interpolator;
            var timeProvider = context.TimeProvider;
            var dispatcher = context.Dispatcher;

            // Command handlers
            interpolator.AddConcept(new SimplyDeclareCollection(timeProvider));
            interpolator.AddConcept(new SimplyDeclareHand(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyAddCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDrawCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplyDealCard(timeProvider, dispatcher));
            interpolator.AddConcept(new SimplePlayCardHandler(timeProvider, dispatcher));
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
            interpolator.AddConcept(new DealAllHandler(dispatcher));
            interpolator.AddConcept(new AddCardTagsHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new ShuffleHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new DiscardCardsHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new PassTurnHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new StartHandler(timeProvider, dispatcher));
            interpolator.AddConcept(new ClaimOwnershipHandler(dispatcher));
        }
    }
}
