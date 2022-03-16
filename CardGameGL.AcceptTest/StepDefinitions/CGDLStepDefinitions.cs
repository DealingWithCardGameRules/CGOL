using CardGameGL.AcceptTest.Drivers;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class CGDLStepDefinitions
    {
        GameDriver gameDriver = new GameDriver();

        [Given(@"the following ""([^""]*)"" definition:")]
        public void GivenTheFollowingDefinition(string template, string cgdl)
        {
            gameDriver.Load(template, cgdl);
        }

        [When(@"the definition ""([^""]*)"" is processed")]
        public void WhenTheDefinitionIsProcessed(string template)
        {
            gameDriver.Process(template);
        }

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
    }
}
