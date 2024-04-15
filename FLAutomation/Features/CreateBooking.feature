Feature: CreateBooking
	Create Booking for given user


Scenario: Create Booking
	Given Given User is at Login Page
	When User login in Applilcation with valid credentials
	When User Click on Create a booking button
	Then Create Booking should be displayed
	When User Enter PostCide and Verify 
	Then PostCode should verify
	When User Enter Car Plate Number and Search Vehicle
	Then Respected Result Should Available
	When User Click Action Link and Enter Mileage and Click Button
	Then Service Secion Should be displayed
	When User Select services and confirm services
	Then Additional Information section should displayed
	When User put Informaion and confirm
	Then Collection and delivery slot should disply
	When User select Collection and delivery slot and confirm slot
	Then Users for collection and delivery should display
