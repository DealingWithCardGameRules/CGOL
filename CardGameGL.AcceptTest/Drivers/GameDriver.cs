﻿using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace CardGameGL.AcceptTest.Drivers
{
    internal class GameDriver
    {
        readonly Dictionary<string, ICommand[]> library = new();
        readonly CGDLService cgdl;

        public GameDriver()
        {
            cgdl = new CGDLServiceFactory().CreateBasicGame();
        }

        internal void Process(string template)
        {
            foreach (var command in library[template])
            {
                cgdl.Dispatch(command);
            }
        }

        internal void Load(string template, string cgdl)
        {
            library.Add(template, this.cgdl.Parse(cgdl).ToArray());
        }

        internal void CreateLibrary()
        {
            var card = new CreateCard("Pass", "Pass", "Pass", "Does nothing.");
            cgdl.Dispatch(card);
        }

        internal void CreateDiscardPile(string name)
        {
            cgdl.Dispatch(new CreateDeck(name));
        }

        internal void DrawCards(string deck, string hand, int cards)
        {
            for (int i = 0; i < cards; i++)
                DrawCard(deck, hand);
        }

        internal void PlayCard(string hand, string discardPile)
        {
            var card = cgdl.Dispatch(new GetTopCard(hand));
            if (card != null)
                cgdl.Dispatch(new PlayCard(hand, discardPile, card.Instance));
        }

        internal void CheckSize(string collection, int expectedSize)
        {
            var count = cgdl.Dispatch(new CardCount(collection));
            Assert.AreEqual(expectedSize, count);
        }

        internal void DrawCard(string deck, string hand)
        {
            cgdl.Dispatch(new DrawCard(deck, hand));
        }

        internal void AddHand(string hand, int cards)
        {
            cgdl.Dispatch(new CreateHand(hand));
            AddCards(hand, cards);
        }

        internal void AddDeck(string deck, int cards = 0)
        {
            cgdl.Dispatch(new CreateDeck(deck));
            AddCards(deck, cards);
        }

        private void AddCards(string deck, int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                cgdl.Dispatch(new AddCard(deck, "Pass"));
            }
        }
    }
}
