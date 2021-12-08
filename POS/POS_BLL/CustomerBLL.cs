using System;
using System.Collections.Generic;
using POS_BO;
using POS_DAL;

namespace POS_BLL
{
    public class CustomerBLL
    {
        public static int generateCustomerID()
        {
           BaseDAL baseDAL = new BaseDAL();
            return baseDAL.generateID("Customer.csv");
        }
        public void addTheCustomer(CustomerBO customerBO)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            customerDAL.SaveCustomer(customerBO);

        }
        public void updateTheCustomer(int id)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<CustomerBO> customerListofBO = customerDAL.getListOfAllCustomer("Customer.csv");

            foreach (CustomerBO customerBO in customerListofBO)
            {
                if (customerBO.CustomerID == id)
                {
                    this.printCustomerDetail(customerBO);
                    Console.Write("\nDo You Really Want to Modify it? (Y/N):\t");
                    ConsoleKeyInfo confirm = Console.ReadKey();

                    if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
                    {
                        Console.Write("\nNew Name:\t");
                        string name = Console.ReadLine();

                        Console.Write("New Address:\t");
                        string address = Console.ReadLine();

                        Console.Write("New Phone:\t");
                        string phone = Console.ReadLine();

                        Console.Write("New Email:\t");
                        string email = Console.ReadLine();

                        int saleLimit;
                        Console.Write("New Sale Limit:\t");
                        int.TryParse(Console.ReadLine(), out saleLimit);

                        int amountPayable;
                        Console.Write("New Amount Payable:\t");
                        int.TryParse(Console.ReadLine(), out amountPayable);


                        if (name != "")
                        {
                            customerBO.Name = name;
                        }
                        if (address != "")
                        {
                            customerBO.Address = address;
                        }
                        if (phone != "")
                        {
                            customerBO.Phone = phone;
                        }
                        if (email != "")
                        {
                            customerBO.Email = email;
                        }
                        if (saleLimit != default)
                        {
                            customerBO.SalesLimit = saleLimit;
                        }
                        if (amountPayable != default)
                        {
                            customerBO.AmountPayable = amountPayable;
                        }

                        customerDAL.deleteFile("Customer.csv");

                        foreach (CustomerBO i in customerListofBO)
                        {
                            customerDAL.SaveCustomer(i);
                        }
                        Console.WriteLine("\nItem Information Sucessfully Updated!");
                    }
                }
            }
        }

        public void findTheCustomer(int id, string name, string email, string phone, int salesLimit)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<CustomerBO> customerListofBO = customerDAL.getListOfAllCustomer("Customer.csv");
            foreach (CustomerBO customerBO in customerListofBO)
            {
                if (customerBO.CustomerID == id || customerBO.Name == name  ||customerBO.Email == email || customerBO.Phone == phone || customerBO.SalesLimit == salesLimit)
                {
                    this.printCustomerDetail(customerBO);
                }
            }
        }
        public bool isCustomerExist(int id)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<CustomerBO> customerListofBO = customerDAL.getListOfAllCustomer("Customer.csv");
            foreach (CustomerBO customerBO in customerListofBO)
            {
                if (customerBO.CustomerID == id)
                {
                    return true;
                }
            }
            return false;
        }
        public void removeTheCustomer(int id)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<CustomerBO> customerListofBO = customerDAL.getListOfAllCustomer("Customer.csv");

            foreach (CustomerBO customerBO in customerListofBO)
            {
                if (customerBO.CustomerID == id)
                {
                    Console.Write("\nDo You Really Want to Remove the Item? (Y/N):\t");
                    ConsoleKeyInfo confirm = Console.ReadKey();
                    if (confirm.KeyChar == 'Y' | confirm.KeyChar == 'y')
                    {
                        customerDAL.deleteFile("Customer.csv");
                        foreach (CustomerBO i in customerListofBO)
                        {
                            if (i.CustomerID != id)
                            {
                                customerDAL.SaveCustomer(i);
                            }
                        }
                        Console.WriteLine("\nItem Sucessfully Deleted!");
                    }
                }
            }
        }
        public String getCustomerName(int cusID)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<CustomerBO> customerListofBO = customerDAL.getListOfAllCustomer("Customer.csv");
            foreach (CustomerBO customerBO in customerListofBO)
            {
                if (customerBO.CustomerID == cusID)
                {
                    return customerBO.Name;
                }
            }
            return "";
        }
        public void setCustomerAmountPayable(int cusID,int amt)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<CustomerBO> customerListofBO = customerDAL.getListOfAllCustomer("Customer.csv");
            foreach (CustomerBO customerBO in customerListofBO)
            {
                if (customerBO.CustomerID == cusID)
                {
                    customerBO.AmountPayable=amt;
                    customerDAL.deleteFile("cutomer.csv");
                    foreach (CustomerBO i in customerListofBO)
                    {
                        customerDAL.SaveCustomer(i);
                    }

                }
            }
        }
        private void printCustomerDetail(CustomerBO customerBO)
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,12}\t{1,30}\t{2,30}\t{3,20}\t{4,15:N0}", "CUSTOMER ID", "CUSTOMER NAME", "EMAIL", "PHONE", "SALE LIMIT");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,12}\t{1,30}\t{2,30}\t{3,20}\t{4,15:N0}", customerBO.CustomerID, customerBO.Name, customerBO.Email, customerBO.Phone, customerBO.SalesLimit);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
