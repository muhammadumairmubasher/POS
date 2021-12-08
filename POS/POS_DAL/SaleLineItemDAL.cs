using System;
using System.Collections.Generic;
using POS_BO;

namespace POS_DAL
{
    public class SaleLineItemDAL:BaseDAL
    {
        public void saveSaleLineItem(SaleLineItemBO saleLineItemBO)
        {
            string text=$"{saleLineItemBO.LineNo},{saleLineItemBO.OrderID},{saleLineItemBO.ItemID},{saleLineItemBO.Quantity},{saleLineItemBO.Amount}";
            save(text, "SaleLineItem.csv");
        }
        public List<SaleLineItemBO> getListOfSaleLineItems(string file)
        {
            List<String> fileData = Read(file);
            List<SaleLineItemBO> saleLineItemsList = new List<SaleLineItemBO>();
            foreach (string s in fileData)
            {
                string[] data = s.Split(",");
                SaleLineItemBO saleLineItemBO = new SaleLineItemBO();
                saleLineItemBO.LineNo = System.Convert.ToInt32(data[0]);
                saleLineItemBO.OrderID=System.Convert.ToInt32(data[1]);
                saleLineItemBO.ItemID = System.Convert.ToInt32(data[2]);
                saleLineItemBO.Quantity = System.Convert.ToInt32(data[3]);
                saleLineItemBO.Amount= System.Convert.ToInt32(data[4]);
                
                saleLineItemsList.Add(saleLineItemBO);
            }
            return saleLineItemsList;
        }
    }
}
