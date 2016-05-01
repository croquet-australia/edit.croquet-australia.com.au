Feature: Home Page

Background: 
	Given the website is running

Scenario: Authorised editor signs in with Google account
	Given this is my first visit to the website
	And I have a Google account
	And I am an authorised editor
	When I go to the home page
	Then I should see the Google sign in page
	When I complete the Google sign in page
	Then I should see the editor home page

Scenario: Signed in
	Given I have signed in
	When I go to the home page
	Then I should see the editor home page

Scenario: Unauthorised account
	Given this is my first visit to the website
	And I have a Google account
	And I am an authorised editor
	When I go to the home page
	Then I should see the Google sign in page
	When I complete the Google sign in page
	Then I should see the unauthorised page
