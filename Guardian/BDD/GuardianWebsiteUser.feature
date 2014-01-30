Feature: GuardianWebsiteUser
As a user I want to be able to register with Guardian Website

@NewUser
Scenario: New User
Given Guardian Website
When When I Register a New User
Then I see New User on Guardian Home Page

@GuestUser
Scenario: Guest User
Given Guardian Website
When I Login as Guest User
Then I see Guardian Home Page as a Guest User
