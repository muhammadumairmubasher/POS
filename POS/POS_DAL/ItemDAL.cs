using System;
using System.Collections.Generic;
using System.IO;
using POS_BO;
namespace POS_DAL
{
    public class ItemDAL:  BaseDAL
    {
        public void SaveItem(ItemBO itemBO)
        {
            string text = $"{itemBO.ItemID},{itemBO.Description},{itemBO.Price},{itemBO.Quantity},{itemBO.CreationDate}";
            save(text, "Item.csv");
        }
        public List<ItemBO> getListOfAllItem(string file)
        {
            List<String> fileData = Read(file);
            List<ItemBO> itemList = new List<ItemBO>();
            foreach (string s in fileData)
            {
                string[] data = s.Split(",");
                ItemBO itemBO = new ItemBO();
                itemBO.ItemID = System.Convert.ToInt32(data[0]);
                itemBO.Description = data[1];
                itemBO.Price = System.Convert.ToDecimal(data[2]);
                itemBO.Quantity = System.Convert.ToInt32(data[3]);
                itemList.Add(itemBO);
            }
            return itemList;
        }
    }
}
