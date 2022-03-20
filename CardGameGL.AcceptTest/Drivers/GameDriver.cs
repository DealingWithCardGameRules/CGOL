using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace CardGameGL.AcceptTest.Drivers
{
    internal class GameDriver
    {
        readonly CGDLService cgdl;

        public GameDriver()
        {
            cgdl = new CGDLServiceFactory().CreateBasicGame();
        }

        internal void Process(string source)
        {
            cgdl.Parse(source);
        }

        internal void CreateLibrary()
        {
            var card = new CreateCard("Pass", "Pass", "Pass", "Does nothing.");
            cgdl.Dispatch(card);
        }

        internal void ChooseDrawCard()
        {
            var commands = cgdl.Dispatch(new GetAvailableActions());
            var drawCommand = commands.First(c => c is DrawCard);
            if (drawCommand != null)
                cgdl.Dispatch(drawCommand);
        }

        internal void ChoosePLayCard()
        {
            var commands = cgdl.Dispatch(new GetAvailableActions());
            var playCommand = (PlayCard)commands.First(c => c is PlayCard);
            var card = cgdl.Dispatch(new GetTopCard(playCommand.Source)) ?? throw new Exception($"No cards in {playCommand.Source}");
            playCommand.Card = card.Instance;
            cgdl.Dispatch(playCommand);
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
                cgdl.Dispatch(new AddCard("Pass", deck));
            }
        }
    }
}
