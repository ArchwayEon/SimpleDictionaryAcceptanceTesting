Feature: Add Word
As a student, I want to add a word and its meaning, so that I can get smart.


Background: 
	Given I am on the add word page

@Normal_Flow
Scenario: I successfully add a new word
	Given I have entered Triangle as the Word
		And I have entered 3-sided shape as the Meaning
	When I press Create
	Then the app should respond with the index page
		And I can see Triangle on the page

