using System;
using System.Collections.Generic;
using POS_BO;
using POS_DAL;

namespace POS_Views
{
    public class ReportsMenu
    {
        public void showReport()
        {
            int choice = 1;
            while (choice != 3)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("\t\tReport Menu");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1 Stock in Hand");
                Console.WriteLine("2 Sale Report");
                Console.WriteLine("3 Exist");
                Console.WriteLine("----------------------------------------------");
                do
                {
                    if (!(choice >= 1 && choice <= 3))
                    {
                        Console.WriteLine("...OOPS!You Enter Wrong Choice!");
                    }
                    Console.Write("Please Enter Menu Choice(1-3):\t");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (!(choice >= 1 && choice <= 5));

                switch (choice)
                {
                    case 1:
                        this.stockInHands();
                        break;
                    case 2:
                        this.salesReport();
                        break;
                    case 3:
                        break;
                }
            }
        }
        void stockInHands()
        {
      
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("\t\t Stock in Hands Report");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("{0,7}\t{1,20}\t{2,15:C}\t{3,15:N0}", "ITEM ID", "DESCRIPTION", "PRICE", "QUANTITY");
            Console.WriteLine("----------------------------------------------------------------");

            ItemDAL itemDAL = new ItemDAL();
            List<ItemBO> itemListOfBO = itemDAL.getListOfAllItem("item.csv");
            foreach (ItemBO item in itemListOfBO)
            {
                Console.WriteLine("{0,7}\t{1,20}\t{2,15:C}\t{3,15:N0}", item.ItemID, item.Description, item.Price, item.Quantity);

            }
            Console.WriteLine("----------------------------------------------------------------");
        }
        void salesReport()
        {

            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("\t\t\t Sales Reports");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("{0,7}\t{1,15}\t{2,15:C}\t{3,15:N0}", "ORDER ID", "ITEM ID", "AMOUNT", "QUANTITY");
            Console.WriteLine("----------------------------------------------------------------");

            SaleLineItemDAL saleLineItemDAL = new SaleLineItemDAL();
            List<SaleLineItemBO> saleLineItemListofBO = saleLineItemDAL.getListOfSaleLineItems("SaleLineItem.csv");
            foreach (SaleLineItemBO item in saleLineItemListofBO)
            {
        
                Console.WriteLine("{0,7}\t{1,20}\t{2,15:C}\t{3,15:N0}", item.ItemID, item.ItemID, item.Amount, item.Quantity);

            }
            Console.WriteLine("----------------------------------------------------------------");
        }

    }
}
