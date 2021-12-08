using System;
using POS_BLL;
using POS_BO;

namespace POS_Views
{
    public class ItemsMenu
    {
        //Implementation Of Module-01
        public int showItemMenu()
        {
            int choice = 1;
            while (choice!=5)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("\t\tItem Menu");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1 Add New Items");
                Console.WriteLine("2 Update Item Details");
                Console.WriteLine("3 Find Items");
                Console.WriteLine("4 Remove Exixting Items");
                Console.WriteLine("5 Back to Main Menu");
                Console.WriteLine("----------------------------------------------");
                do
                {
                    if (!(choice >= 1 && choice <= 5))
                    {
                        Console.WriteLine("...OOPS!You Enter Wrong Choice!");
                    }
                    Console.Write("Please Enter Item Menu Choice(1-5):\t");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (!(choice >= 1 && choice <= 5));

                switch (choice)
                {
                    case 1:
                        this.addNewItem();
                        break;
                    case 2:
                        this.modifyItemDetails();
                        break;
                    case 3:
                        this.findItem();
                        break;
                    case 4:
                        this.removeExistingItem();
                        break;
                    case 5:
                        choice=this.backToMainMenu();
                        break;
                }
            }
            return choice;
        }
        private void addNewItem()
        {
            decimal pr;
            int qty;

            Console.Write("Enter Item Description:\t");
            string des = Console.ReadLine();

            Console.Write("Enter Item Price:\t");
            decimal.TryParse(Console.ReadLine(), out pr);

            Console.Write("Enter Item Quantity:\t");
            int.TryParse(Console.ReadLine(), out qty);

            Console.Write("Do You Really Want to realy Save it? (Y/N):\t");
            ConsoleKeyInfo confirm = Console.ReadKey();

            if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
            {
                ItemBO itemBO = new ItemBO
                {
                    ItemID = ItemBLL.generateItemID(),
                    Description = des,
                    Price = pr,
                    Quantity = qty
                };

                ItemBLL itemBLL = new ItemBLL();
                itemBLL.addTheItem(itemBO);

                Console.WriteLine("\nItem Information Sucessfully Saved!");
            }
           
        }
        private void modifyItemDetails()
        {
            int id;
            Console.Write("Enter Item ID which you want to Modify:\t");
            int.TryParse(Console.ReadLine(), out id);
            ItemBLL itemBLL = new ItemBLL();
            itemBLL.updateTheItem(id);
        }
        private void findItem()
        {
            int id;
            decimal pr;
            int qty;
            DateTime date;
            Console.WriteLine("Please specify atleat one of Following to find the item.");
            Console.Write("Item ID:\t");
            int.TryParse(Console.ReadLine(), out id);

            Console.Write("Description:\t");
            string des = Console.ReadLine();

            Console.Write("Price:\t");
            decimal.TryParse(Console.ReadLine(), out pr);

            Console.Write("Quantity:\t");
            int.TryParse(Console.ReadLine(), out qty);

            Console.Write("Creation Date (mm/dd/yyyy):\t");
            DateTime.TryParse(Console.ReadLine(), out date);

            ItemBLL itemBLL = new ItemBLL();
            itemBLL.findTheItem(id,des,pr,qty,date);
        }
        private void removeExistingItem()
        {
            int id;
            Console.Write("Enter Item ID which you want to Remove:\t");
            int.TryParse(Console.ReadLine(), out id);
            ItemBLL itemBLL = new ItemBLL();
            itemBLL.removeTheItem(id);
        }
        private int backToMainMenu()
        {
            return 5;
        }
    }
}