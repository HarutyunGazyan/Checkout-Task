In this exercise: 

This is a proof of concept of a checkout application developed by one of our interns which needs to go live later this week.

Before launch, there is some feedback from the business side regarding the experience and checkout validation that needs our attention:
 - The product list currently shows all offers. 
	- It should instead show one item per Product
	- Each Product should show the name and extra info from the Product's cheapest Offer. 
 
- Checkout Validation
	- The field Zip Code should be four digits for orders to Norway, five digits for orders to Sweden and Finland.
	- All fields are required, except Norwegian orders that do not require the field Telephone. Please hide this field for Norwegian offers.
  

Assignment: 
 - How should we implement the new business requirements in time, and what code improvements can we manage to include before launch?
 - Use git, follow best practice providing commits. Implement the required changes along with some code improvements that can be included before the initial launch. Show how you write code, and what you consider most important to fix first.
 - Think about further improvements, and be ready to discuss these topics further:
	- The project does not follow our normal standards. How can this project evolve to allow us to switch from Razor Pages to for example a Vue.js front-end, without having to re-implement all business logic? 
	- Review and note down other suggestions of improvements to this project, for example providing more clear separation of concerns, making the code less error prone or improving its readability.
	- Be prepared to discuss details about why you suggest each change, and why you choose some suggestions before others.



 Remarks: 
 - The DataContext is an in memory database, but contains a small set of real world data. Please treat it as our real database for now, another developer will switch it to our real database before going live. 
 - The external API that receives orders is out of our control and does not validate orders in the way business wishes. Please keep this in mind.


Spend as much time on this task as you wish, but we expect no more than an hour. Concentrate on what you find most important to show us from a design perspective and to get the application launched in time. Bring the rest to our discussion during the technical interview. 
The deadline is one hour before our interview. Please share the code with us in any way you like. If you use an online platform, make sure you send us a link and make it publicly accessible.