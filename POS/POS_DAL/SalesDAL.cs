using System;
using System.Collections.Generic;
using POS_BO;

namespace POS_DAL
{
    public class SalesDAL:BaseDAL
    {
        public void saveSaleDetail(SalesBO salesBO)
        {
            string text = $"{salesBO.OrderID},{salesBO.CustomerID},{salesBO.Date},{salesBO.Status}";
            save(text, "Sales.csv");
        }
        public List<SalesBO> getListOfAllSales(string file)
        {
            List<String> fileData = Read(file);
            List<SalesBO> salesList = new List<SalesBO>();
            foreach (string s in fileData)
            {
                string[] data = s.Split(",");
                SalesBO salesBO = new SalesBO();
                salesBO.OrderID = System.Convert.ToInt32(data[0]);
                salesBO.CustomerID = System.Convert.ToInt32(data[1]);
                salesBO.Date = System.Convert.ToDateTime(data[2]);
                salesBO.Status = System.Convert.ToBoolean(data[3]);
                salesList.Add(salesBO);
            }
            return salesList;
        }
    }
}
