using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndcultureCodingChallenge.Specflow.PageObjects
{
	public abstract class BasePageObject
	{
        public abstract string PagePath { get; }

        public abstract IPage Page { get; set; }

        public abstract IBrowser Browser { get; }

        public async Task NavigateAsync()
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
        }
    }
}
