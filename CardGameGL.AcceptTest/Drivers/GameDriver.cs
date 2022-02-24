﻿using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts;
using Microsoft.Extensions.DependencyInjection;

namespace CardGameGL.AcceptTest.Drivers
{
    internal class GameDriver
    {
        ServiceProvider serviceProvider;
        IDispatcher dispatcher;

        public GameDriver()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCardGameDescriptionLanguage();
            serviceCollection.AddSingleton(p => p.GetRequiredService<GDLFactory>().Create());
            serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<GDLSetup>()?.AddHandlers();
            dispatcher = serviceProvider.GetService<IDispatcher>() ?? throw new Exception("No dispatcher service available");
        }

        internal void DrawCards(Guid deck, Guid hand, int cards)
        {
            for (int i = 0; i < cards; i++)
                DrawCard(deck, hand);
        }

        internal void CheckSize(Guid collectionId, int expectedSize)
        {
            var count = dispatcher.Dispatch(new CardCount(collectionId));
            Assert.AreEqual(expectedSize, count);
        }

        internal void DrawCard(Guid deck, Guid hand)
        {
            dispatcher.Dispatch(new DrawCard(deck, hand));
        }

        internal void AddHand(Guid handId, int cards)
        {
            dispatcher.Dispatch(new CreateHand(handId));
            AddCards(handId, cards);
        }

        internal void AddDeck(Guid deckId, int cards = 0)
        {
            dispatcher.Dispatch(new CreateStack(deckId));
            AddCards(deckId, cards);
        }

        private void AddCards(Guid deckId, int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                var card = new BlankCard();
                dispatcher.Dispatch(new AddCard(deckId, card));
            }
        }
    }

    class BlankCard : ICard
    {
        public Guid Template => Guid.Empty;
        public Guid Instance => Guid.NewGuid();
        public string Name => "Pass";
    }
}
