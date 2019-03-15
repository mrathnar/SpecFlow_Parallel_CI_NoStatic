Feature: VerifyGet
Scenario Outline: Test response of Get method  using end point
Given i have a url
When i call get keyword <CityName>
Then get api response in jason format
Examples:
| CityName  |
| Hyderaba  |
| Chennai   |
| Bangalore |
| Kerala    |


