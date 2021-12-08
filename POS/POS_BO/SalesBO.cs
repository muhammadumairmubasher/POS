using System;
namespace POS_BO
{
    public class SalesBO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
