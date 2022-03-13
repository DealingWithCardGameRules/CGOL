using CardGameGL.AcceptTest.Support;
using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CardGameGL.AcceptTest.Drivers
{
    internal class GameDriver
    {
        ServiceProvider serviceProvider;
        IDispatcher dispatcher;
        CardGameDLParser parser;
        Dictionary<string, ICommand[]> library = new Dictionary<string, ICommand[]>();

        public GameDriver()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCardGameDescriptionLanguage();
            serviceCollection.AddSingleton(p => p.GetRequiredService<GDLFactory>().Create());
            serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<SimpleGameSetup>()?.AddHandlers();
            var disp = serviceProvider.GetService<IDispatcher>() ?? throw new Exception("No dispatcher service available.");
            parser = serviceProvider.GetService<CardGameDLParser>() ?? throw new Exception("No CGDL parser.");
            dispatcher = new DispatchLogger(disp);
        }

        internal void Process(string template)
        {
            foreach (var command in library[template])
            {
                dispatcher.Dispatch(command);
            }
        }

        internal void Load(string template, string cgdl)
        {
            library.Add(template, parser.Parse(cgdl).ToArray());
        }

        internal void CreateDiscardPile(string name)
        {
            dispatcher.Dispatch(new CreateDeck(name));
        }

        internal void DrawCards(string deck, string hand, int cards)
        {
            for (int i = 0; i < cards; i++)
                DrawCard(deck, hand);
        }

        internal void PlayCard(string hand, string discardPile)
        {
            var card = dispatcher.Dispatch(new GetTopCard(hand));
            if (card != null)
                dispatcher.Dispatch(new PlayCard(hand, discardPile, card.Instance));
        }

        internal void CheckSize(string collection, int expectedSize)
        {
            var count = dispatcher.Dispatch(new CardCount(collection));
            Assert.AreEqual(expectedSize, count);
        }

        internal void DrawCard(string deck, string hand)
        {
            dispatcher.Dispatch(new DrawCard(deck, hand));
        }

        internal void AddHand(string hand, int cards)
        {
            dispatcher.Dispatch(new CreateHand(hand));
            AddCards(hand, cards);
        }

        internal void AddDeck(string deck, int cards = 0)
        {
            dispatcher.Dispatch(new CreateDeck(deck));
            AddCards(deck, cards);
        }

        private void AddCards(string deck, int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                var card = new BlankCard();
                dispatcher.Dispatch(new AddCard(deck, card));
            }
        }
    }

    class BlankCard : ICard
    {
        public Guid Template => Guid.Empty;
        public Guid Instance { get; }
        public string Name => "Pass";

        public BlankCard()
        {
            Instance = Guid.NewGuid();
        }
    }
}
