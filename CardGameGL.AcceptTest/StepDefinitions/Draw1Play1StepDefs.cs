using CardGameGL.AcceptTest.Drivers;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class Draw1Play1StepDefs
    {
        GameDriver gameDriver = new GameDriver();
        Guid deck;
        Guid hand;

        [Given(@"a deck of (.*) cards?")]
        public void GivenADeckOfCards(int cards)
        {
            deck = Guid.NewGuid();
            gameDriver.AddDeck(deck, cards);
        }

        [Given(@"a player with (.*) cards")]
        public void GivenAPlayerWithCards(int cards)
        {
            hand = Guid.NewGuid();
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
    }
}
