namespace AndcultureCodingChallenge.Specflow.StepDefinitions
{
	[Binding]
	public sealed class CalculatorStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
		int a = 0;
		int b = 0;
		int result = 0;

		private readonly ScenarioContext _scenarioContext;

		public CalculatorStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("the first number is (.*)")]
		public void GivenTheFirstNumberIs(int number)
		{
			//TODO: implement arrange (precondition) logic
			// For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
			// To use the multiline text or the table argument of the scenario,
			// additional string/Table parameters can be defined on the step definition
			// method. 

			//throw new PendingStepException();
			a = number;
		}

		[Given("the second number is (.*)")]
		public void GivenTheSecondNumberIs(int number)
		{
			//TODO: implement arrange (precondition) logic

			//throw new PendingStepException();
			b=number;
		}

		[When("the two numbers are added")]
		public void WhenTheTwoNumbersAreAdded()
		{
			//TODO: implement act (action) logic

			//throw new PendingStepException();
			result = a + b;
		}

		[Then("the result should be (.*)")]
		public void ThenTheResultShouldBe(int result)
		{
			//TODO: implement assert (verification) logic

			//throw new PendingStepException();
			this.result.Should().Be(result);
		}
	}
}