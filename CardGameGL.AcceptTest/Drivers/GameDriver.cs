using dk.itu.game.msc.cgol;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;

namespace CardGameGL.AcceptTest.Drivers
{
    internal class GameDriver
    {
        readonly CGOLService cgol;

        public GameDriver()
        {
            cgol = new CGOLServiceFactory().CreateBasic();
        }

        internal void Process(string source)
        {
            cgol.Parse(source);
        }

        internal void CreateLibrary()
        {
            var card = new CreateCard("Pass");
            cgol.Dispatch(card);
        }

        internal void ChooseDrawCard()
        {
            var commands = cgol.Dispatch(new GetAvailableActions());
            var drawCommand = commands.First(c => c.Command is DrawCard);
            if (drawCommand != null)
                cgol.Dispatch(drawCommand.Command);
        }

        internal void ChoosePLayCard()
        {
            var commands = cgol.Dispatch(new GetAvailableActions());
            var playCommand = (PlayCard)commands.First(c => c.Command is PlayCard).Command;
            var card = cgol.Dispatch(new GetTopCard(playCommand.Source)) ?? throw new Exception($"No cards in {playCommand.Source}");
            playCommand.Card = card.Instance;
            cgol.Dispatch(playCommand);
        }

        internal void CreateDiscardPile(string name)
        {
            cgol.Dispatch(new CreateDeck(name));
        }

        internal void DrawCards(string deck, string hand, int cards)
        {
            for (int i = 0; i < cards; i++)
                DrawCard(deck, hand);
        }

        internal void PlayCard(string hand, string discardPile)
        {
            var card = cgol.Dispatch(new GetTopCard(hand));
            if (card != null)
                cgol.Dispatch(new PlayCard(hand, discardPile, card.Instance));
        }

        internal void CheckSize(string collection, int expectedSize)
        {
            var count = cgol.Dispatch(new CardCount(collection));
            Assert.AreEqual(expectedSize, count);
        }

        internal void DrawCard(string deck, string hand)
        {
            cgol.Dispatch(new DrawCard(deck, hand));
        }

        internal void AddHand(string hand, int cards)
        {
            cgol.Dispatch(new CreateHand(hand));
            AddCards(hand, cards);
        }

        internal void AddDeck(string deck, int cards = 0)
        {
            cgol.Dispatch(new CreateDeck(deck));
            AddCards(deck, cards);
        }

        private void AddCards(string deck, int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                cgol.Dispatch(new AddCard("Pass", deck));
            }
        }
    }
}
