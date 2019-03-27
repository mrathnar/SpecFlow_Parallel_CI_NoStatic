Feature: Soap_Verify_Post
@API
Scenario: Verify SOAP Post Response
Given i have a soap urls
When i perfrom post request
Then get api response in xml Formats
