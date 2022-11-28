using dk.itu.game.msc.cgol;
using dk.itu.game.msc.cgol.Common;
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

        internal async Task CreateLibrary()
        {
            var card = new CreateCard("Pass");
            await cgol.Dispatch(card);
        }

        internal async Task ChooseDrawCard()
        {
            var commands = (await cgol.Dispatch(new GetAvailableActions()))();
            var drawCommand = await commands.FirstAsync(c => c.Command is DrawCard);
            if (drawCommand != null)
                await cgol.Dispatch(drawCommand.Command);
        }

        internal async Task ChoosePLayCard()
        {
            var commands = (await cgol.Dispatch(new GetAvailableActions()))();
            var playCommand = (PlayCard)(await commands.FirstAsync(c => c.Command is PlayCard)).Command;
            var card = await cgol.Dispatch(new GetTopCard(await playCommand.Source.Value(null))) ?? throw new Exception($"No cards in {playCommand.Source}");
            playCommand.Card = new MaybeChoice<Guid>(card.Instance);
            await cgol.Dispatch(playCommand);
        }

        internal async Task CreateDiscardPile(string name)
        {
            await cgol.Dispatch(new CreateDeck(name));
        }

        internal async Task DrawCards(string deck, string hand, int cards)
        {
            for (int i = 0; i < cards; i++)
                await DrawCard(deck, hand);
        }

        internal async Task PlayCard(string hand, string discardPile)
        {
            var card = await cgol.Dispatch(new GetTopCard(hand));
            if (card != null)
                await cgol.Dispatch(new PlayCard(hand, discardPile, card.Instance));
        }

        internal async Task CheckSize(string collection, int expectedSize)
        {
            var count = await cgol.Dispatch(new CardCount(collection));
            Assert.AreEqual(expectedSize, count);
        }

        internal async Task DrawCard(string deck, string hand)
        {
            await cgol.Dispatch(new DrawCard(deck, hand));
        }

        internal async Task AddHand(string hand, int cards)
        {
            await cgol.Dispatch(new CreateHand(hand));
            await AddCards(hand, cards);
        }

        internal async Task AddDeck(string deck, int cards = 0)
        {
            await cgol.Dispatch(new CreateDeck(deck));
            await AddCards(deck, cards);
        }

        private async Task AddCards(string deck, int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                await cgol.Dispatch(new AddCard("Pass", deck));
            }
        }
    }
}
