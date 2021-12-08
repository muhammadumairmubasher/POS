using System;
using System.Collections.Generic;
using POS_BO;

namespace POS_DAL
{
    public class CustomerDAL : BaseDAL
    {
        public void SaveCustomer(CustomerBO customerBO)
        {
            string text = $"{customerBO.CustomerID},{customerBO.Name},{customerBO.Address},{customerBO.Phone},{customerBO.Email},{customerBO.SalesLimit},{customerBO.AmountPayable}";
            save(text, "Customer.csv");
        }
        public List<CustomerBO> getListOfAllCustomer(string file)
        {
            List<String> fileData = Read(file);
            List<CustomerBO> customerList = new List<CustomerBO>();
            foreach (string s in fileData)
            {
                string[] data = s.Split(",");
                CustomerBO customerBO = new CustomerBO();
                customerBO.CustomerID = System.Convert.ToInt32(data[0]);
                customerBO.Name = data[1];
                customerBO.Address = data[2];
                customerBO.Phone = data[3];
                customerBO.Email = data[4];
                customerBO.SalesLimit = System.Convert.ToInt32(data[5]); ;
                customerBO.AmountPayable= System.Convert.ToInt32(data[6]);
                customerList.Add(customerBO);
            }
            return customerList;
        }
    }
}

