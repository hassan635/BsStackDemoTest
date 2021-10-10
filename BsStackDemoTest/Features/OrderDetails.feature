Feature: OrderDetails
BS Stack Demo page for ordered products


Scenario Outline: Ordered product title should be identical to product listing
	Given I am logged in as demouser
	When I select product from the Product page with product title '<Product_Title>'
	And I checkout the product(s)
	Then The product title '<Product_Title>' on the Orders page should be identical to Product Page
	Examples: 
	| Product_Title |
	| iPhone 11     |
	| iPhone 12     |

Scenario: Total order cost should be calculated correctly
	Given I am logged in as demouser
	When I select product from the Product page with product title 'iPhone 12'
	And I select product from the Product page with product title 'iPhone 12 Mini'
	And I checkout the product(s)
	Then The total order cost should be '1498'