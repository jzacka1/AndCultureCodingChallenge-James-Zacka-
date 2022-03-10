using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndcultureCodingChallenge.Specflow.PageObjects
{
	public class ReactHomePageObject : BasePageObject
	{
		public override string PagePath => "https://localhost:44431/";

		public ReactHomePageObject(IBrowser browser)
		{
			Browser = browser;
		}

		public override IPage Page { get; set; }

		public override IBrowser Browser { get; }

		public async Task<string> CheckForItemsInList(){
			return await Page.Locator("#root table tr:nth-child(2)").InnerTextAsync();
		}

		public async Task FillSearchBar(string search){
			await Page.Locator("#search").FillAsync(search);
		}

		public async Task ClickOnDetailsLink() {
			await Page.ClickAsync("#root table tr:nth-child(2) > td:last-child a");
		}
	}
}
