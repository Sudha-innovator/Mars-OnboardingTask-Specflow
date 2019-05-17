Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario: Test01 Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

Scenario: Test02 Check if seller could be able to add a duplicate language
    Given I click on the language tab to add existing language
	When I add the duplicate language
	Then The seller should not allow to add 

Scenario: Test03 Check if seller can be able to edit the existing language
      Given I click on the language tab to check edit
	  When I click edit button and change the language level
	  Then The language level should be updated with new info

Scenario: Test04 Check if seller can be able to add fifth record in language
       Given I click on the language tab to check max limit
	   When I try to add fifth record 
	   Then The seller should not allo to add

Scenario: Test05 Check if seller can be able to delete the language record
       Given I click on the language tab to check Delete function
	   When I click on the delete icon for the first record
	   Then The record should be deleter from the list.

Scenario Outline: Test02 scenario outline with Adding Multiple record 
       Given I click on the Language tab to add multiple records
	   When I enter '<name>' and '<level>' and click add new button
	   Then the record '<name>' should be added to the list 
	   

	   Examples: 
	   | name   | level          | namechk |
	   | Telugu | Fluent         | Telugu  |
	   | Tamil  | Conversational | Tamil   |
	   | Hindi  | Basic          | Hindi   |