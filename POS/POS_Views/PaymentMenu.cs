using System;
using POS_BLL;
using POS_BO;

namespace POS_Views
{
    public class PaymentMenu
    {
       public void MakePayment()
       {
           int ordID;
           Console.Write("\nEnter SaleID:\t");
           int.TryParse(Console.ReadLine(),out ordID);

           SaleBLL saleBLL=new SaleBLL();
           if(saleBLL.isValidSaleID(ordID))
           {
               CustomerBLL customerBLL=new CustomerBLL();
               string customerName=customerBLL.getCustomerName(saleBLL.getCustomerID(ordID));

               Console.WriteLine("Customer Name:\t {0}", customerName);

                int totalSales = 40000;
               Console.WriteLine("Total Sale Amount:\t {0:C}", totalSales);
               Console.WriteLine("Amount Paid:\t {0:C}", 0);
               Console.WriteLine("Remaing Amount:\t {0:C}", totalSales);
               int amountToBePaid;
               Console.Write("Amount to be Paid:\t");
               int.TryParse(Console.ReadLine(), out amountToBePaid);

            }
            else
            {
               Console.WriteLine("...OOPS! No Record exist against given Sale ID");
            }

       }
    }
}
