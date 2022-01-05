Feature: ApplyCoupon
	Apply coupon code 'edgewords' to a 'clothing item' on the cart page

@Coupon_Test
Scenario: Check coupon is correctly applied
	When I am on the Cart page
	Then I apply coupon code 'edgewords'
	Then Subtotal is equal to %15 less than item's original price