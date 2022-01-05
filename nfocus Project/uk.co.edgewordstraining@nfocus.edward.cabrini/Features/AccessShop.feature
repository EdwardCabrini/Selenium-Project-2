Feature: Access shop
	Add clothing item to cart and verify item is in cart

Background:
	Given I am on the My Account page

@Shop_test
Scenario: Add an item to the cart
	When I access the Shop page
	Then I add a 'clothing item' to cart
	Then I access the Cart Page
	Then I have the same 'clothing item' in cart table