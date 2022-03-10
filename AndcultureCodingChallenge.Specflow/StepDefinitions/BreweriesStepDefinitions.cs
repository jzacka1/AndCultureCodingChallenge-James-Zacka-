using AndcultureCodingChallenge.Specflow.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AndcultureCodingChallenge.Specflow.StepDefinitions
{
    [Binding]
    public class BreweriesStepDefinitions
    {
        private readonly ReactHomePageObject _reactHomePageObject;

        public BreweriesStepDefinitions(ReactHomePageObject reactHomePageObject) { 
            _reactHomePageObject = reactHomePageObject; 
        }

        [Given(@"a Home page")]
        public async Task GivenAHomePage()
        {
            await _reactHomePageObject.NavigateAsync();
        }

        [Then(@"a list of breweries is returned")]
        public void ThenAListOfBreweriesIsReturned()
        {
            _reactHomePageObject
                .CheckForItemsInList()
                .Result
                .Should()
                .Be("10-56 Brewing Company\tmicro\t400 Brown Cir, Knox, Indiana,\t\tDetails");
        }

        [When(@"I click on the Details link")]
        public async Task WhenIClickOnTheDetailsLink()
        {
            await _reactHomePageObject.ClickOnDetailsLink();
        }

        [Then(@"I am directed to the Details page")]
        public void ThenIAmDirectedToTheDetailsPage()
        {
			_reactHomePageObject.Page.Url.Should().Contain("10-56");
		}

        [Given(@"'([^']*)' is in Search Bar")]
        public async Task GivenIsInSearchBar(string search)
        {
            
        }

        [Given(@"a value is in Search Bar")]
        public async Task GivenAValueIsInSearchBar(Table table)
        {
            foreach(var item in table.Rows){
                var value = ((string[])item.Values)[0];

				await _reactHomePageObject.FillSearchBar(value);
			}
        }

        [Then(@"items are shown")]
        public void ThenItemsAreShown()
        {
            //_reactHomePageObject
            //    .CheckForItemsInList()
            //    .Result
            //    .Should()
            //    .Contain();
        }




    }
}
