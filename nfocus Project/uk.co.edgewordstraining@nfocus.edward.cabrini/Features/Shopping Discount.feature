Feature: Shopping Discount

Background:
	Given I am on the login page

@Discount_Order_Test
Scenario: Discount test
	When I login with 'username' and 'password'
	Then I am on the My Account page
	When I access the Shop page
	Then I add a 'clothing item' to cart
	Then I access the Cart Page
	Then I have the same 'clothing item' in cart table
	Then I apply coupon code 'edgewords'
	Then Subtotal is equal to %15 less than item's original price
	When I am on the checkout page
	Then I input valid billing information
	And Select 'check payments'
	Then I place the order
	Then I get the order reference