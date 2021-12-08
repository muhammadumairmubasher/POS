using System;
using POS_BLL;
using POS_BO;

namespace POS_Views
{
    public class SaleMenu
    {
        //Implementation Of Module-03
        public int MakeNewSale()
        {
            // create Sale Object
            SalesBO salesBO = new SalesBO
            {
                OrderID = SaleBLL.generateSalesID(),
                Date = DateTime.Now,
                Status=false
            };
            Console.WriteLine($"Sales ID: {salesBO.OrderID}");
            Console.WriteLine($"Sale Date: {salesBO.Date}");

            int cusID;
            Console.Write("Enter Customer ID:\t");
            int.TryParse(Console.ReadLine(),out cusID);

            CustomerBLL customerBLL = new CustomerBLL();
            
            if(customerBLL.isCustomerExist(cusID))
            {
                salesBO.CustomerID = cusID;
                salesBO.Status = true;

                SaleBLL saleBLL = new SaleBLL();
                saleBLL.addSaleDetail(salesBO);

                this.addNewItemInSale(salesBO);
                this.ShowSaleMenu(salesBO);
            }
            else
            {
                Console.WriteLine("...OOPS! No Customer Exixt Against Given ID");
            }

            return 5;
        }
        private int ShowSaleMenu(SalesBO salesBO)
        {
            int choice = 1;
            while (choice != 4)
            {
                Console.WriteLine("\n\nPress 1 to Enter New Items");
                Console.WriteLine("Press 2 to End Sale");
                Console.WriteLine("Press 3 to Remove an existing Item from the currrent Sale");
                Console.WriteLine("Press 4 to Cancel Sale");
                Console.WriteLine("----------------------------------------------");
                do
                {
                    if (!(choice >= 1 && choice <= 4))
                    {
                        Console.WriteLine("...OOPS!You Enter Wrong Choice!");
                    }
                    Console.Write("Choice from Option(1-4):\t");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (!(choice >= 1 && choice <= 4));

                switch (choice)
                {
                    case 1:
                        this.addNewItemInSale(salesBO);
                        break;
                    case 2:
                        this.endSale(salesBO);
                        choice=4;
                        break;
                    case 3:
                        this.removeExistingItemFromCurrentSale(salesBO);
                        break;
                    case 4:
                        this.cancelSale(salesBO);
                        break;
                }
            }
            return choice;
        }

        private void addNewItemInSale(SalesBO salesBO)
        {
            int itemID;
            Console.Write("\n\nEnter Item Id: ");
            int.TryParse(Console.ReadLine(),out itemID);

            (string description, decimal price) descriptionAndPrice = ItemBLL.getItemDescriptionOrPrice(itemID);
            if (descriptionAndPrice.description != "ItemNotExist" && descriptionAndPrice.price != -99)
            {
                Console.WriteLine($"Description: {descriptionAndPrice.description}");
                Console.WriteLine($"Price: {descriptionAndPrice.price}");
                Console.Write("Quantity: ");
                
                int quantity;
                int.TryParse(Console.ReadLine(), out quantity);
                int amount = System.Convert.ToInt32(descriptionAndPrice.price) * quantity;
                Console.WriteLine($"Sub-Total: {amount}");
                
                SaleLineItemBO saleLineItemBO = new SaleLineItemBO
                {
                    LineNo = SaleLineItemBLL.generateSalesLineItemsID(),
                    OrderID = salesBO.OrderID,
                    ItemID = itemID,
                    Quantity = quantity,
                    Amount = amount,
                };
                SaleLineItemBLL saleLineItemBLL = new SaleLineItemBLL();
                saleLineItemBLL.addSaleLineItemDetails(saleLineItemBO);
            }
            else
            {
                Console.WriteLine("...OOPS! No Item Exist Against Given ID");
            }
        }
        private void endSale(SalesBO salesBO)
        {
            SaleLineItemBLL saleLineItemBLL = new SaleLineItemBLL();
            CustomerBLL customerBLL=new CustomerBLL();
            Console.WriteLine("\nSale ID:{0,5}\t\t\t\t\tCustomerID: {1}",salesBO.OrderID,salesBO.CustomerID);
            Console.WriteLine("Sale Date:{0,20}\t\t\tName: {1}",salesBO.Date ,customerBLL.getCustomerName(salesBO.CustomerID));

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("{0,7}\t{1,20}\t{2,15:N0}\t{3,15:C}", "ITEM ID", "DESCRIPTION", "QUANTITY", "AMOUNT");
            Console.WriteLine("----------------------------------------------------------------");
            int totalSales= saleLineItemBLL.getSaleLineItemDetails(salesBO.OrderID);
            Console.WriteLine("Total Sales:\t{0,50:C}", totalSales);
            Console.WriteLine("----------------------------------------------------------------");
            customerBLL.setCustomerAmountPayable(salesBO.CustomerID, totalSales);
        }
         private void removeExistingItemFromCurrentSale(SalesBO salesBO)
        {
            int id;
            Console.Write("Enter Item ID which you want to Remove:\t");
            int.TryParse(Console.ReadLine(), out id);
            SaleLineItemBLL saleLineItemBLL = new SaleLineItemBLL();
            saleLineItemBLL.removeTheItemFromSaleLineItem(id,salesBO.OrderID);
        }
        private void cancelSale(SalesBO salesBO)
        {
            SaleBLL saleBLL = new SaleBLL();
            saleBLL.removeTheSale(salesBO.OrderID);
            SaleLineItemBLL saleLineItemBLL = new SaleLineItemBLL();
            saleLineItemBLL.removeAllItemsAgainstSale(salesBO.OrderID);
        }
    }
}