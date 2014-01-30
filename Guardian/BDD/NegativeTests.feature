Feature: NegativeTests
As a user I want to ensure negative testing is covered

@ScenarioRegisterBlankUser
Scenario: RegisterBlankUser
	Given Guardian Site
	When I Register a Blank User
	Then Required Field Error Message is returned

@ScenarioRegisterInvalidUserData
Scenario: RegisterInvalidUserData
	Given Guardian Site
	When I Register User with Invalid User Data
	Then Invalid Error Message is returned

@ScenarioIncompleteRegistration
Scenario: IncompleteRegistration
	Given Guardian Site
	When I Register User with Incomplete Registration Details
	Then Mandatory Requirement Error Message is returned
