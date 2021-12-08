using System;
using POS_BLL;
using POS_BO;

namespace POS_Views
{
    public class App
    {
        public void mainMenu()
        {
            int choice = 1; 
            while (choice != 6) 
            {
                Console.WriteLine("\n**********************************************");
                Console.WriteLine("\t\tWelcome to Admin");
                Console.WriteLine("**********************************************");
                Console.WriteLine("1 Mange Items");
                Console.WriteLine("2 Manage Customers");
                Console.WriteLine("3 Make New Sale");
                Console.WriteLine("4 Make Payment");
                Console.WriteLine("5 Print Reports");
                Console.WriteLine("6 Exit");
                
                Console.WriteLine("**********************************************");
                //Get Input from user until choice is not betweeen 1 and 6
                do
                {
                    if (choice < 1 || choice > 6)
                    {
                        Console.WriteLine("...OOPS!You Enter Wrong Choice!");
                    }
                    Console.Write("Please Enter Your Choice(1-6):\t");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (!(choice >= 1 && choice <= 6));    //Not between 1 & 6

                switch (choice)
                {
                    case 1:
                    //Module-01
                        ItemsMenu itemsMenu = new ItemsMenu();
                        choice=itemsMenu.showItemMenu();
                        break;
                    case 2:
                    //Module-02
                        CustomersMenu customersMenu = new CustomersMenu();
                        choice = customersMenu.showCustomerMenu();
                        break;
                    case 3:
                    //Module-03
                        SaleMenu saleMenu = new SaleMenu();
                        choice=saleMenu.MakeNewSale();
                        break;
                    case 4:
                    //Module-04
                        PaymentMenu paymentMenu=new PaymentMenu();
                        paymentMenu.MakePayment();
                        break;
                    case 5:
                        //Module-05
                        ReportsMenu reportsMenu = new ReportsMenu();
                        reportsMenu.showReport();
                        break;
                    case 6:
                        choice=6;   //sentinal value
                        break;
                }
            }
        }
    }
}
