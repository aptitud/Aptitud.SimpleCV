Feature: Create new Consultant from AuthenticationInformation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add Consultant with email without prior profile
	Given email test.user@aptitud.se doesn't have a profile
	When executing Post to /api/commands/createprofilefromauthentication containing 
	"""
	{ 
		"name": "Test User",
		"email" : "test.user@aptitud.se"
	}
	"""
	Then the HttpStatusCode should be Created
	And with header location /profile/test.user@aptitud.se
	And email test.user@aptitud.se should have a profile