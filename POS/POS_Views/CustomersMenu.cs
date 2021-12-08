using System;
using POS_BLL;
using POS_BO;

namespace POS_Views
{
    public class CustomersMenu
    { 
        //Implementation Of Module-02
        public int showCustomerMenu()
        {
            int choice = 1;
            while (choice != 5)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("\t\tCustomer Menu");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1 Add New Customer");
                Console.WriteLine("2 Update Customer Details");
                Console.WriteLine("3 Find Customer");
                Console.WriteLine("4 Remove Exixting Customer");
                Console.WriteLine("5 Back to Main Menu");
                Console.WriteLine("----------------------------------------------");
                //Get Input from user until choice is not betweeen 1 and 5
                do
                {
                    if (!(choice >= 1 && choice <= 5))
                    {
                        Console.WriteLine("...OOPS!You Enter Wrong Choice!");
                    }
                    Console.Write("Please Enter Customer Menu Choice(1-5):\t");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (!(choice >= 1 && choice <= 5)); //Not between 1 & 5

                switch (choice)
                {
                    case 1:
                        this.addNewCustomer();
                        break;
                    case 2:
                        this.modifyCustomerDetails();
                        break;
                    case 3:
                        this.findCustomer();
                        break;
                    case 4:
                        this.removeExistingCustomer();
                        break;
                    case 5:
                        choice = this.backToMainMenu(); //Sentinal Value
                        break;
                }
            }
            return choice;
        }
        private void addNewCustomer()
        {
            Console.Write("Enter Customer Name:\t");
            string name = Console.ReadLine();

            Console.Write("Enter Customer Address:\t");
            string address = Console.ReadLine();

            Console.Write("Enter Customer Phone:\t");
            string phone = Console.ReadLine();

            Console.Write("Enter Customer Email:\t");
            string email = Console.ReadLine();

            int saleLimit;
            Console.Write("Enter Customer Sale Limit:\t");
            int.TryParse(Console.ReadLine(), out saleLimit);


            Console.Write("Do You Really Want to realy Save it? (Y/N):\t");
            ConsoleKeyInfo confirm = Console.ReadKey();

            if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
            {
                CustomerBO customerBO = new CustomerBO
                {
                    CustomerID = CustomerBLL.generateCustomerID(),
                    Name = name,
                    Address = address,
                    Phone = phone,
                    Email = email,
                    SalesLimit = saleLimit,
                    AmountPayable = default
                };

                CustomerBLL customerBLL = new CustomerBLL();
                customerBLL.addTheCustomer(customerBO);

                Console.WriteLine("\nCustomer Information Sucessfully Saved!");
            }
        }
        private void modifyCustomerDetails()
        {
            int id;
            Console.Write("Enter Customer ID which you want to Modify:\t");
            int.TryParse(Console.ReadLine(), out id);
            CustomerBLL customerBLL = new CustomerBLL();
            customerBLL.updateTheCustomer(id);
        }
        private void findCustomer()
        {
            int id;
            Console.WriteLine("Please specify atleat one of Following to find the item.");
            Console.Write("Customer ID:\t");
            int.TryParse(Console.ReadLine(), out id);

            Console.Write("Name:\t");
            string name = Console.ReadLine();

            Console.Write("Email:\t");
            string email = Console.ReadLine();

            Console.Write("Phone:\t");
            string phone = Console.ReadLine();

            int saleLimit;
            Console.Write("Sales Limit:\t");
            int.TryParse(Console.ReadLine(), out saleLimit);

            CustomerBLL customerBLL = new CustomerBLL();
            customerBLL.findTheCustomer(id, name, email, phone, saleLimit);
        }
        private void removeExistingCustomer()
        {
            int id;
            Console.Write("Enter Customer ID which you want to Remove:\t");
            int.TryParse(Console.ReadLine(), out id);
            CustomerBLL customerBLL = new CustomerBLL();
            customerBLL.removeTheCustomer(id);
        }
        private int backToMainMenu()
        {
            return 5;
        }
    }
}
