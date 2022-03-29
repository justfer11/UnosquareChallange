Feature: Search
	Search, count elements, compare prices, check items availables, and remove items, 
	from microsofot windows application page.

@E2ETest
Scenario: Search Item, Count Elements, Add and Remove from chart
	Given I go to 'microsoft' in 'es-mx' locale
	And I go to Windows page
	When I search for Xbox item
	Then I go to Comprar page
	And I go to Aplicaciones view
	When I count the elements in the three first pages
	Then I print the sum of all elements and titles
	When I back to first page
	Then I select first NON-FREE option and store the price
	And I close Registration pop up
	Then I compare the price from the items list view vs item detailed page
	When I click on add to cart from the three dots next to comprar button
	Then I redirect to shopping cart page and verify one element is available
	Then I delete the item and verify zero elements are available along with Tu carro está vacio message.


