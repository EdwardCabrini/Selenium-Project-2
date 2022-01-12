Feature: Login to Checkout

Complete the process of logging in, applying a discount, checkingout, and loggingout

Background: 
	Given I am on the login page

Scenario: Complete new session checkout process
	When I login with 'edward.cabrini@nfocus.co.uk' and 'Man_of_Chaos2567'
	Then I place the order
	And I apply coupon code 'edgewords'
	When I complete checkout with valid billing information
	Then I will recieve correct order number