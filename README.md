# Point of Sale Terminal (POS)

This based on the Concepts related to multi tier architecture, file
I/O, collections and other utilities in .Net.

---
## Problem Statement

The problem statement is pretty simple. We need a software implementation of a Point of Sale terminal at a typical store. The users of the system are the cashiers sitting at the sales terminals of the store. The users can use the system to manage sales items in the store, customer details and of course the sales. The system should be capable of presenting some reports related to the sales, items and customers. All data should be stored in flat file system. You’ll come to know about the details later in this handout.

--- 
User Interface
---
You are not put in the trouble of creating some fancy GUIs at the moment. What you are supposed to do is to develop a simple console based system. When the system starts the user is presented with the main menu as follows:


## Main Menu
1. Manage Items
2. Manage Customers
3. Make New Sale
4. Make Payment
5. Print Reports
6. Exit

Press 1 to 5 to select an option:
The user selects his/her desired option by pressing one of the numbers from 1 to 5.
Upon selecting an option from the main menu the system presents user with a corresponding sub menu. The details are as follows:

## Items Menu
1. Add new Item
2. Update Item details
3. Find Items
4. Remove Existing Item
5. Back to Main Menu

Press 1 to 5 to select an option:

## Customers Menu

1. Add new Customer
2. Update Customer details
3. Find Customer
4. Remove Existing Customer
5. Back to Main Menu
Press 1 to 5 to select an option:

## Reports Menu

1. Stock in Hand
2. Customer Balance
3. Sales Report (by date)
4. Outstandinding Sales (by Date)
5. Back to Main Menu
Press 1 to 5 to select an option:

--- 
Items Menu
--- 
When the user selects the “Manage Items” option from the main menu he/she is presented with the “Items Menu”. The user is allowed to add new Item, update Item information and to search for Items and also remove an existing Item.

## Add New Item

When the user selects add new Item option, he is presented with the system generated (new) Item Id and then prompts the user to enter the following information of the Item: 
- Description
- Price
- Quantity 

Upon getting all info the system confirms from the user to save the info and then if the user confirms the system saves the info to file shows confirmation message (e.g. Item Information successfully saved) and again the Item Menu. Note that when a new Item is added the creation date will be the current date to be stored in the file.

## Modify Item Details

The system asks user to enter Item Id and then if found displays the item data. Then the system asks user to enter the item details which he wants to modify and to leave blank otherwise. Upon getting all info the system confirms from the user to save the info and then if the user confirms the system saves the info to file shows confirmation message (e.g. Item Information successfully saved) and again the Item Menu.

## Find Item

The system asks the user to enter any of the item info and then finds the item from the file according to the given information. The user can leave blank the fields he/she does not want in the search criteria. e.g. the screen presented should look like this:

Please specify atleast one of the following to find the item. Leave all fields blank to return to

Customers Menu:  
Item ID:  
Description:  
Price:  
Quantity:  
Creation Date:

If the item is found then its details are displayed or an appropriate message is displayed on the screen. Following output is shown to the user:

![image](https://user-images.githubusercontent.com/59522109/145240602-9a72d682-b8cb-4b50-adb5-5fa9693a9609.png)

## Remove Existing Item

User enters the “Item ID“ and if a valid item id exist then a confirmation from the user is asked. After confirmation the specified “Item ID” is removed from the file.  

Note that an item should only be allowed to remove if there is no recorded sale for the item at the moment and appropriate message should be displayed to the user for those items.

--- 
Customers Menu
--- 
When the user selects the “Manage Customers” option from the main menu he/she is presented with the “Customers Menu”.  
The user is allowed to add new customers, update their information and to search for customers and also remove an existing customer.

## Add New Customer
When the user selects add new customer option, he is presented with the system generated (new) Customer Id and then prompts the user to enter the following information of the customer:  
Name, Address, Phone and Email, Sales Limit. 
Upon getting all info the system confirms from the user to save the info and then if t he user confirms the system saves the info to file shows confirmation message (e.g. Customer Information successfully saved) and again the Customers Menu.

Note that when a new customer is added his payable amount will be zero.

## Modify Customer Details

The system asks user to enter Customer Id and then if found displays the customer data. Then the system asks user to enter the customer details which he wants to modify and to leave blank otherwise. 
Upon getting all info the system confirms from the user to save the info and then if the user confirms the system saves the info to file shows confirmation message (e.g. Customer Information successfully saved) and again the Customers Menu.

## Find Customer

The system asks the user to enter any of the customer info and then finds the customer from the file according to the given information. The user can leave blank the fields he/she does not want in the search criteria. 
e.g. the screen presented should look like this:  
Please specify atleast one of the following to find the customer. Leave all fields blank to
return to Customers Menu:

Customer ID:
Name:
Email:
Phone:
Sales Limit:

If the customer is found then his details are displayed or an appropriate message is displayed on the screen. Following output is shown to the customer:
![image](https://user-images.githubusercontent.com/59522109/145241208-2f7fd93a-d8a7-4d27-b842-a411d2446aa7.png)

## Remove Existing Customer

User enters the “Customer ID“ and if a valid customer id exist then a confirmation from the user is asked. After confirmation the specified “Customer ID” is removed from the file.  
Note that a “Customer ID” which is associated with any sales cannot be removed from the system and appropriate message should be displayed to the user.

---
Make New Sale
---

When the user selects the “Make New Sale” option from the Main Menu, the screen appears with the sale date/time and Sales ID of the new sale. The cashier is prompted to enter the “CustomerID” and system waits for input from the cashier.

Example screen:  

Sales ID: 1  
Sales Date: 05/06/2006  
Enter Customer ID: 2  

The cashier is then asked to add items for this sales.He is prompted to enter "ItemID" and system waits for input from the cashier. As soon as the cashier enters ItemID, system displays item “Description” and “Price” if a correct ItemID is found and prompts cashier to enter “Quantity”.

Example screen:  

Item Id:  
Description: C#: The Complete Reference. 
Price: Rs. 650.00  
Quantity: 1  
Sub-Total: Rs. 650.00  

Press 1 to Enter New Item  
Press 2 to End Sale  
Press 3 to Remove an existing Item from the current sale  
Press 4 to Cancel Sale  
Choose from option 1 – 4:  

Note: Text in red represents user input and in green represent system generated output.

**Enter New Item**

When the user types “1”, the system responds by prompting user once again for new Item Id as before and upon entry of each new item the system displays the “Total amount payable”. The process of entering new items will continue until all items have been processed at which point the cashier selects the "End Sale" option by typing “2”.

**End Sale**

This system operation will involve computing the total for the sale and communicating it to the user by displaying on the console. Following output should be displayed after ending the sale:

![image](https://user-images.githubusercontent.com/59522109/145246119-5ce00871-5b69-49d9-8f82-f0b8ae52b7cf.png)
![image](https://user-images.githubusercontent.com/59522109/145246189-b051ce92-bc2a-41ed-915a-a541478c6fa3.png)

The user will be taken to the Main Menu after ending the sale.
Note that the total sales for asingle day for a single customer should not exceed the sale limit of the customer.
Note that every new sale created against a customer will increase the customer balance by the sales amount.

---
Make Payment
---
The system prompts the user to enter the “Sales ID” and if a valid “Sales ID” is given then following output is shown:

Sale ID: 3  
Customer Name: Javed Ahmed  
Total Sales Amount: 30,000  
Amount Paid: 17,550  
Remaing Amount: 12,450  
Amount to be Paid: 10,000 

In the above output the user will enter the amount to be paid for making the payments against the sale. Following action will be taken after a payment is entered:
- A new payment will be recorded
- Customer balance will be decreased for the associated customer

Note that the amount paid is calculated using the sum of all amounts of receipts of given “Sales ID”.

## View Reports

If the user selects view reports then he/she should be asked to specify one of the following reports:

6. Stock in Hand
7. Customer Balance
8. Sales Report (by date)
9. Outstandinding Sales (by Date)

## Stock in hand

The user is asked for an “Item ID” range as an input. Then, he is presented with a summary of stock in hand as follows:  
![image](https://user-images.githubusercontent.com/59522109/145247046-c366f92c-33d4-4f4a-b27e-b38338f28d85.png)

The user is prompted for two dates to specify the period for which the report is to be generated. If the user leaves bland one of the dates then the report is printed for a single day. The report format is as follows:  
![image](https://user-images.githubusercontent.com/59522109/145247240-31aca0ca-0b89-4d98-99fa-6d7c19c730a5.png)
![image](https://user-images.githubusercontent.com/59522109/145247288-b71285ef-b0cf-45fd-9ef0-687f3c8c0ea2.png)

## Outstanding Sales

The user is prompted for two dates to specify the period for which the report is to be generated. If the user leaves blank one of the dates then the report is printed for a single day. The report format is as follows:  
![image](https://user-images.githubusercontent.com/59522109/145247419-b00b49ee-bef3-4b7a-b96c-6a9e1bea6aa9.png)


## Design Information and Requirements

- Use flat file systems to store all data the format of the files is given below but broadly you should have one file for customer information, second for items information, third for sales and fourth for receipts.
- You should also have different classes for: Customer, Item and Sale. Make sure you separate the implementation from the interface completely using N-Tier architecture because we are going to ask you to give the same assignment with GUI features later on.
- All data entry points should have proper error checks and error messages.
- **All data entry is through command line interface.**
- There must be proper commenting through out your code.
- The code should be well indented and easy to read as your marking depends a lot on this.

## File System

The data to be preserved in files is given below:

- **Item** (ItemId, Description, Price, Quantity, CreationDate)
- **Customer** (CustomerId, Name, Address, Phone, Email, AmountPayable, Sales Limit)
- **Sale** (OrderId, CustomerId, Date, Status)
- **SaleLineItem** (LineNo, OrderId, ItemId, Quantity, Amount)
- **Receipt** (ReceiptNo, ReceiptDate, OrderId, Amount)

The underlined attributes are unique (key attributes) and your system autogenerates these numbers. You need to store all data in plain text files.
