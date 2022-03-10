using TechTalk.SpecFlow;

namespace AndcultureCodingChallenge.Specflow.Hooks
{
	[Binding]
	public sealed class CalculatorHooks
	{
		// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

		[BeforeScenario("@mytag")]
		public void BeforeScenarioWithTag()
		{
			// Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
			// See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

			//TODO: implement logic that has to run before executing each scenario
			Console.WriteLine("Before is called");
		}

		[BeforeScenario(Order = 1)]
		public void FirstBeforeScenario()
		{
			// Example of ordering the execution of hooks
			// See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

			//TODO: implement logic that has to run before executing each scenario
			Console.WriteLine("First is called");
		}

		[AfterScenario]
		public void AfterScenario()
		{
			//TODO: implement logic that has to run after executing each scenario
			Console.WriteLine("After is called");
		}
	}
}