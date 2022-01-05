Feature: Login to Edgewords training site
	Access edgewrods training site on chrome and perform login with valid username and password

Background:
	Given I am on the login page

@Login_Test
Scenario: Valid login
	When I login with 'username' and 'password'
	Then I am on the My Account page
