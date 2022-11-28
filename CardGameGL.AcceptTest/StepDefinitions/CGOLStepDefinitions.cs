using CardGameGL.AcceptTest.Drivers;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class CGOLStepDefinitions
    {
        GameDriver gameDriver = new GameDriver();

        [Then(@"the ""([^""]*)"" should have (.*) cards?")]
        public async Task ThenTheShouldHaveCard(string collection, int cards)
        {
            await gameDriver.CheckSize(collection, cards);
        }

        [When(@"the player choses DrawCard")]
        public async Task WhenThePlayerChosesDrawCard()
        {
            await gameDriver.ChooseDrawCard();
        }

        [Given(@"the player has chosen DrawCard")]
        public async Task GivenThePlayerHasChosenDrawCard()
        {
            await gameDriver.ChooseDrawCard();
        }

        [When(@"the player choses PlayCard")]
        public async Task WhenThePlayerChosesPlayCard()
        {
            await gameDriver.ChoosePLayCard();
        }

        [Given(@"the following:")]
        public void GivenTheFollowing(string cgol)
        {
            gameDriver.Process(cgol);
        }
    }
}
