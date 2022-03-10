Feature: Breweries

A short summary of the feature

@BreweriesList
Scenario: Load List of Breweries
	Given a Home page
	Then a list of breweries is returned

@BrewerySearch
Scenario Outline: Search Brewery with <search>
	Given a Home page
	And a value is in Search Bar
| search |
| 10     |
|  z     |
	Then items are shown

@BreweriesDetails
Scenario: Open Details Link
	Given a Home page
	When I click on the Details link
	Then I am directed to the Details page
