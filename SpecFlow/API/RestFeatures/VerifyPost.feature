Feature: VerifyPost
@API
Scenario: Update data
Given i have a url of app
When i call put keyword "posts"
Then insert data in jason format
