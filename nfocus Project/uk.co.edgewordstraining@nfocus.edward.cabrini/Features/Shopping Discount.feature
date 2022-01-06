Feature: Shopping Discount

Background:
	Given I am on the login page

@Login_Test
Scenario: Discount test
	When I login with 'username' and 'password'
	Then I am on the My Account page
	When I access the Shop page
	Then I add a 'clothing item' to cart
	Then I access the Cart Page
	Then I have the same 'clothing item' in cart table
	When I am on the Cart page
	Then I apply coupon code 'edgewords'
	Then Subtotal is equal to %15 less than item's original price