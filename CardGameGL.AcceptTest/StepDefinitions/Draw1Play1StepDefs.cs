using CardGameGL.AcceptTest.Drivers;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class Draw1Play1StepDefs
    {
        GameDriver gameDriver = new GameDriver();
        Guid discardPile = new Guid("FF9B0F0F-2F98-4CD5-9AB6-79B64EDDC6F9");
        Guid deck = new Guid("B5EAB8C4-95EF-4247-AA9F-F5542EC1525B");
        Guid hand = new Guid("6E39D361-A3E1-4610-A943-2517B830050B");

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

    }
}
