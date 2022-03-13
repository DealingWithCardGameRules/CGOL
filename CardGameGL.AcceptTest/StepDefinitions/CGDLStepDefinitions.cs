using CardGameGL.AcceptTest.Drivers;
using System;
using TechTalk.SpecFlow;

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

        [Then(@"the ""([^""]*)"" should have (.*) card")]
        public void ThenTheShouldHaveCard(string collection, int cards)
        {
            gameDriver.CheckSize(collection, cards);
        }

    }
}
