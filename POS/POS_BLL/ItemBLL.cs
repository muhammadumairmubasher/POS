using System;
using System.Collections.Generic;
using System.IO;
using POS_BO;
using POS_DAL;

namespace POS_BLL
{
    public class ItemBLL
    {
        public void addTheItem(ItemBO itemBO)
        {
            ItemDAL itemDAL = new ItemDAL();
            itemDAL.SaveItem(itemBO);
        }
        public void updateTheItem(int id)
        {
            ItemDAL itemDAL = new ItemDAL();
            List<ItemBO> itemListOfBO = itemDAL.getListOfAllItem("item.csv");

            foreach (ItemBO item in itemListOfBO)
            {
                if (item.ItemID == id)
                {
                    this.printItemDetail(item);
                    Console.Write("\nDo You Really Want to Modify it? (Y/N):\t");
                    ConsoleKeyInfo confirm = Console.ReadKey();

                    if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
                    {
                        decimal pr;
                        int qty;

                        Console.Write("\nEnter New Description:\t");
                        string des = Console.ReadLine();

                        Console.Write("Enter New Price:\t");
                        decimal.TryParse(Console.ReadLine(), out pr);

                        Console.Write("Enter New Quantity:\t");
                        int.TryParse(Console.ReadLine(), out qty);

                        if (des != "")
                        {
                            item.Description = des;
                        }
                        if (pr != default)
                        {
                            item.Price = pr;
                        }
                        if (qty != default)
                        {
                            item.Quantity = qty;
                        }
                        itemDAL.deleteFile("item.csv");

                        foreach (ItemBO i in itemListOfBO)
                        {
                            itemDAL.SaveItem(i);
                        }
                        Console.WriteLine("\nItem Information Sucessfully Saved!");
                    }
                }
            }
        }
        public void findTheItem(int id, string des, decimal pr, int qty, DateTime date)
        {
            ItemDAL itemDAL = new ItemDAL();
            List<ItemBO> itemListof_BO = itemDAL.getListOfAllItem("item.csv");
            foreach (ItemBO item in itemListof_BO)
            {
                if (item.ItemID == id || item.Description == des|| item.Price == pr || item.Quantity == qty || item.CreationDate == date)
                {
                    this.printItemDetail(item);
                }
            }
        }
        public void removeTheItem(int id)
        {
            ItemDAL itemDAL = new ItemDAL();
            List<ItemBO> itemListof_BO = itemDAL.getListOfAllItem("item.csv");
            foreach (ItemBO item in itemListof_BO)
            {
                if (item.ItemID == id)
                {
                    Console.Write("\nDo You Really Want to Remove the Item? (Y/N):\t");
                    ConsoleKeyInfo confirm = Console.ReadKey();
                    if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
                    {
                        itemDAL.deleteFile("item.csv");
                        foreach (ItemBO i in itemListof_BO)
                        {
                            if(i.ItemID != id)
                            {
                                itemDAL.SaveItem(i);
                            }
                        }
                        Console.WriteLine("\nItem Sucessfully Deleted!");
                    }
                }
            }
        }
        private void printItemDetail(ItemBO item)
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("{0,7}\t{1,20}\t{2,15:C}\t{3,15:N0}", "ITEM ID", "DESCRIPTION", "PRICE", "QUANTITY");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("{0,7}\t{1,20}\t{2,15:C}\t{3,15:N0}", item.ItemID, item.Description, item.Price, item.Quantity);
            Console.WriteLine("----------------------------------------------------------------");
        }

        public static (string description, decimal price) getItemDescriptionOrPrice(int id)
        {
            ItemDAL itemDAL = new ItemDAL();
            List<ItemBO> itemListOfBO = itemDAL.getListOfAllItem("item.csv");
            foreach (ItemBO i in itemListOfBO)
            {
                if (i.ItemID == id)
                {
                    return (i.Description, i.Price);
                }
            }
            return ("ItemNotExist", -99);
        }
        public static void decreaseItemQuantity(int id, int qty)
        {
            ItemDAL itemDAL = new ItemDAL();
            List<ItemBO> itemListOfBO = itemDAL.getListOfAllItem("item.csv");
            foreach (ItemBO i in itemListOfBO)
            {
                if (i.ItemID == id)
                {
                    i.Quantity=i.Quantity-qty;  
                    itemDAL.deleteFile("item.csv");
                    foreach (ItemBO item in itemListOfBO)
                    {
                        itemDAL.SaveItem(item);
                    } 
                }
            }
        }
        public static int generateItemID()
        {
           BaseDAL baseDAL = new BaseDAL();
            return baseDAL.generateID("Item.csv");
        }
        // public static void increaseItemQuantity(int id, int qty)
        // {
        //     ItemDAL itemDAL = new ItemDAL();
        //     List<ItemBO> itemListOfBO = itemDAL.getListOfAllItem("item.csv");
        //     foreach (ItemBO i in itemListOfBO)
        //     {
        //         if (i.ItemID == id)
        //         {
        //             i.Quantity=i.Quantity+qty;  
        //             itemDAL.deleteFile("item.csv");
        //             foreach (ItemBO item in itemListOfBO)
        //             {
        //                 itemDAL.SaveItem(item);
        //             } 
        //         }
        //     }
        // }
    }
}
