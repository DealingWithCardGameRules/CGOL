using CardGameGL.AcceptTest.Drivers;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class Draw1Play1StepDefs
    {
        GameDriver gameDriver = new GameDriver();
        readonly string discardPile = "discard pile";
        readonly string deck = "deck";
        readonly string hand = "hand";

        [Given(@"a deck of (.*) cards?")]
        public void GivenADeckOfCards(int cards)
        {
            gameDriver.AddDeck(deck, cards);
        }

        [Given(@"a player with (.*) cards?")]
        public void GivenAPlayerWithCards(int cards)
        {
            gameDriver.AddHand(hand, cards);
        }

        [When(@"the player draws (.*) cards?")]
        public void WhenPlayerDrawsCard(int cards)
        {
            gameDriver.DrawCards(deck, hand, cards);
        }

        [Then(@"the player should have (.*) cards?")]
        public void ThenPlayerShouldHaveCard(int cards)
        {
            gameDriver.CheckSize(hand, cards);
        }

        [When(@"the player plays (.*) card")]
        public void WhenThePlayerPlaysCard(int cards)
        {
            gameDriver.PlayCard(hand, discardPile);
        }

        [Given(@"a discard pile")]
        public void GivenADiscardPile()
        {
            gameDriver.CreateDiscardPile(discardPile);
        }

        [Given(@"a library")]
        public void GivenALibrary()
        {
            gameDriver.CreateLibrary();
        }

    }
}
