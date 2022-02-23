using CardGameGL.AcceptTest.Drivers;
using System;
using TechTalk.SpecFlow;

namespace CardGameGL.AcceptTest.StepDefinitions
{
    [Binding]
    public class Draw1Play1StepDefs
    {
        GameDriver game = new GameDriver();
        Guid stack;

        [Given(@"a stack of (.*) cards?")]
        public void GivenAStackOfCards(int cards)
        {
            stack = Guid.NewGuid();
            game.AddStack(stack, cards);
        }

        [Given(@"(?:a|the) player with (.*) cards")]
        public void GivenAPlayerWithCards(int cards)
        {
            throw new PendingStepException();
        }

        [When(@"(?:a|the) player draws (.*) cards?")]
        public void WhenDrawsCard(int cards)
        {
            throw new PendingStepException();
        }

        [Then(@"(?:a|the) player should have (.*) cards?")]
        public void ThenShouldHaveCard(int cards)
        {
            throw new PendingStepException();
        }
    }
}
