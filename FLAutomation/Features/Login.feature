Feature: Login

Verify login funcitonality for given user

Scenario: Login scenario of Fleet
	Given Given User is at Login Page
	When User login in Applilcation with valid credentials
	And LogOut button should be displayed
	When User LogOut from the Application
	Then Login Page should available

	
