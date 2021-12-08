using System;
namespace POS_BO
{
    public class CustomerBO
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SalesLimit { get; set; }
        public int AmountPayable { get; set; }
    }
}
