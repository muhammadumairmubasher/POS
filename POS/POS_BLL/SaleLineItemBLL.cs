using System;
using System.Collections.Generic;
using POS_BO;
using POS_BLL;
using POS_DAL;

namespace POS_BLL
{
    public class SaleLineItemBLL
    {
        public void addSaleLineItemDetails(SaleLineItemBO saleLineItemBO)
        {
            SaleLineItemDAL saleLineItemDAL = new SaleLineItemDAL();
            saleLineItemDAL.saveSaleLineItem(saleLineItemBO);
        }
        public int getSaleLineItemDetails(int odrID)
        {
            int sum=0;
            SaleLineItemDAL itemDAL = new SaleLineItemDAL();
            List<SaleLineItemBO> saleLineItemListofBO = itemDAL.getListOfSaleLineItems("SaleLineItem.csv");
            foreach (SaleLineItemBO item in saleLineItemListofBO)
            {
                if(item.OrderID==odrID)
                {
                    sum=sum+item.Amount;
                    ItemBLL.decreaseItemQuantity(item.ItemID,item.Quantity);
                    Console.WriteLine("{0,7}\t{1,20}\t{2,15:N0}\t{3,15:C}", item.ItemID , ItemBLL.getItemDescriptionOrPrice(item.ItemID).description , item.Quantity, item.Amount);
                }
            }
            Console.WriteLine("----------------------------------------------------------------");
            return sum;
        }
        public void removeTheItemFromSaleLineItem(int itemId,int ordID)
        {
            SaleLineItemDAL saleLineItemDAL = new SaleLineItemDAL();
            List<SaleLineItemBO> saleLineItemListofBO = saleLineItemDAL.getListOfSaleLineItems("SaleLineItem.csv");
            foreach (SaleLineItemBO i in saleLineItemListofBO)
            {
                if (i.ItemID == itemId && i.OrderID == ordID)
                {
                    Console.Write("\nDo You Really Want to Remove the Item? (Y/N):\t");
                    ConsoleKeyInfo confirm = Console.ReadKey();
                    if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
                    {
                        saleLineItemDAL.deleteFile("SaleLineItem.csv");
                        foreach (SaleLineItemBO saleLineItemBO in saleLineItemListofBO)
                        {
                            if (!(saleLineItemBO.ItemID == itemId && saleLineItemBO.OrderID == ordID))
                            {  
                                saleLineItemDAL.saveSaleLineItem(saleLineItemBO);   
                            }
                        }
                        Console.WriteLine("\nItem Sucessfully Deleted!");
                    }
                }
            }
        }
        public void removeAllItemsAgainstSale(int ordId)
        {
            SaleLineItemDAL saleLineItemDAL = new SaleLineItemDAL();
            List<SaleLineItemBO> saleLineItemListofBO = saleLineItemDAL.getListOfSaleLineItems("SaleLineItem.csv");
            foreach (SaleLineItemBO saleLineItem in saleLineItemListofBO)
            {
                if (saleLineItem.OrderID == ordId)
                {
                    saleLineItemDAL.deleteFile("SaleLineItem.csv");
                    foreach (SaleLineItemBO saleLineItemBO in saleLineItemListofBO)
                    {
                        if (saleLineItemBO.OrderID != ordId)
                        {
                            saleLineItemDAL.saveSaleLineItem(saleLineItemBO);
                        }
                    }
                }
            }
        }
        public static int generateSalesLineItemsID()
        {
            BaseDAL baseDAL=new BaseDAL();
            return baseDAL.generateID("SalesLineItem.csv");
        }
    }
}
