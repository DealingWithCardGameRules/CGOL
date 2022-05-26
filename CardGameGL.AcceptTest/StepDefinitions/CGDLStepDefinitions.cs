using CardGameGL.AcceptTest.Drivers;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class CGOLStepDefinitions
    {
        GameDriver gameDriver = new GameDriver();

        [Then(@"the ""([^""]*)"" should have (.*) cards?")]
        public void ThenTheShouldHaveCard(string collection, int cards)
        {
            gameDriver.CheckSize(collection, cards);
        }

        [When(@"the player choses DrawCard")]
        public void WhenThePlayerChosesDrawCard()
        {
            gameDriver.ChooseDrawCard();
        }

        [Given(@"the player has chosen DrawCard")]
        public void GivenThePlayerHasChosenDrawCard()
        {
            gameDriver.ChooseDrawCard();
        }

        [When(@"the player choses PlayCard")]
        public void WhenThePlayerChosesPlayCard()
        {
            gameDriver.ChoosePLayCard();
        }

        [Given(@"the following:")]
        public void GivenTheFollowing(string cgol)
        {
            gameDriver.Process(cgol);
        }
    }
}
