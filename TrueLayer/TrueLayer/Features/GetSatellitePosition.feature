Feature: GetSatellitePosition
	Simple calculator for adding two numbers

@mytag
Scenario: Verify the GET operation to check the single position of satellite
	Given Perform Get operation for "/positions"
	And Perfom the operation added timestamp '1436029892'
	Then I should see status code ok 
	And I should see the "name" as "iss"
	And I should see the "visibility" as "daylight"

@mytag
Scenario: Verify the GET operation to check the double positions of satellite
	Given Perform Get operation for "/positions"
	And Perfom the operation added double timestamp "1436029892", "1436029902"
	Then I should see status code ok


@mytag
Scenario: Verify the Get operation when malform the url
	Given Perform Get operation for "/positions"
	And Perform the operation added malform timestamp "143602989'2"
	Then I should see status Bad Request

