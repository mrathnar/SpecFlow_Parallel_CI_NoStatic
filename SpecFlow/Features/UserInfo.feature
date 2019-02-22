Feature: UserInfo
Background: 
Given User navigates to the site
Scenario Outline: Validate user informtion form with valid data
#Given User navigate to site
When Enter data in <UserName> <Password> <EmailID> <Location>
And Clicked on  Login button
Then Login sucessful text will display in text filed <Message>
Examples: 
| UserName | Password  | EmailID          | Location | Message           |
| rathna   | rathna123 | rathna@gmail.com | madurai  | Login : Sucessful |
| reddy    | rathna123 | reddy@gmail.com  | hyderabad| Login : Sucessful |

Scenario: Verify display of user controls(buttons)
#Given User naviate to site
Then page shoud contains following buttons 
| Button1 | Button2 | Button3 |
| Login   | Submit  | Ok      |



