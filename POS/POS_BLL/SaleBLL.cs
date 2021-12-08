using System;
using System.Collections.Generic;
using POS_BO;
using POS_DAL;

namespace POS_BLL
{
    public class SaleBLL
    {
        public void addSaleDetail(SalesBO salesBO)
        {
            SalesDAL salesDAL = new SalesDAL();
            salesDAL.saveSaleDetail(salesBO);
        }
        public void removeTheSale(int odrID)
        {
            SalesDAL salesDAL = new SalesDAL();
            List<SalesBO> salesListofBO = salesDAL.getListOfAllSales("Sales.csv");
            foreach (SalesBO sales in salesListofBO)
            {
                if (sales.OrderID == odrID)
                {
                    Console.Write("\nDo You Really Want to Cancel the Sale? (Y/N):\t");
                    ConsoleKeyInfo confirm = Console.ReadKey();
                    if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
                    {
                        salesDAL.deleteFile("Sales.csv");
                        foreach (SalesBO i in salesListofBO)
                        {
                            if (i.OrderID != odrID)
                            {
                                salesDAL.saveSaleDetail(i);
                            }
                        }
                        Console.WriteLine("\nSale Sucessfully Canceled!");
                    }
                }
            }
        }
        public static int generateSalesID()
        {
           BaseDAL baseDAL = new BaseDAL();
            return baseDAL.generateID("Sales.csv");
        }
        public bool isValidSaleID(int ordID)
        {
            SalesDAL salesDAL = new SalesDAL();
            List<SalesBO> salesListofBO = salesDAL.getListOfAllSales("Sales.csv");
            foreach (SalesBO salesBO in salesListofBO)
            {
                if (salesBO.OrderID == ordID)
                {
                    return true;
                }
            }
            return false;
        }
        public int getCustomerID(int ordID)
        {
            SalesDAL salesDAL = new SalesDAL();
            List<SalesBO> salesListofBO = salesDAL.getListOfAllSales("Sales.csv");
            foreach (SalesBO salesBO in salesListofBO)
            {
                if (salesBO.OrderID == ordID)
                {
                    return salesBO.CustomerID;
                }
            }
            return -1;
        }
    }
}
