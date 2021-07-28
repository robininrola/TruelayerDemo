Feature: GetSatelliteTles
	

@mytag
Scenario: Verify the GET operation to check the Tles of satellite
	Given Perform Get operation for "/tles"
	Then I should see status code ok 
	And I should see the "header" as "ISS (ZARYA)"
	And I should see the "name" as "iss"


@mytag
Scenario: Verify the GET operation to malform the url
	Given Perform Get operation for "/tle's"
	Then I should see status code NotFound
	And I should see the error message "{error: Invalid controller specified (satellites_tl%27es),    status: 404}"