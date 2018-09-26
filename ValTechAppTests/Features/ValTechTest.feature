@StartBrowser
@TearDown
Feature: ValTechTest
Scenario: Test1
Given That I am at the ValTech home page
Then The recent blogs section is displayed
Scenario Outline: Test2
Given That I am at the ValTech home page
When I navugate to the menu option '<menuOption>'
Then I can see the '<section>' header
Examples:
| menuOption | section  |
| About      | About    |
| Work       | Work     |
| Services   | Services |