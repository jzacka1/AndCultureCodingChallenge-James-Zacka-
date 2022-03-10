using AndcultureCodingChallenge.Specflow.PageObjects;
using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace AndcultureCodingChallenge.Specflow.Hooks
{
	[Binding]
	public sealed class BreweriesHooks
	{
		//[BeforeScenario("@BreweriesList", "@BreweriesDetails")]
		[BeforeScenario]
		public async Task BeforeScenario(IObjectContainer container){
			var playwright = await Playwright.CreateAsync();
			var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
			{
				Headless = false,
				Channel = "chrome"
			});
			var pageObject = new ReactHomePageObject(browser);
			container.RegisterInstanceAs(playwright);
			container.RegisterInstanceAs(browser);
			container.RegisterInstanceAs(pageObject);
		}

		[AfterScenario]
		public async Task AfterScenario(IObjectContainer container)
		{
			var browser = container.Resolve<IBrowser>();
			await browser.CloseAsync();
			var playwright = container.Resolve<IPlaywright>();
			playwright.Dispose();
		}
	}
}