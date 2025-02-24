Feature: KitchenApplitools
As User I want to verify the functionality of Kitchen Applitools


@smoke
Scenario: As User I want to verify Drag & Drop Functionality of Kitchen Applitools
	Given Kitchen Applitools homepage is opened
	When Navigate to the 'Drag & Drop' section
	And Drag a 'Hamburger' item from Menu to the Order Ticket area
	Then I should see the text inside the Order Ticket matches 'Hamburger' item
	And I should see the changed color of the Order Ticket area
