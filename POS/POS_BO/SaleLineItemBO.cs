using System;
namespace POS_BO
{
    public class SaleLineItemBO
    {
        public int LineNo { set; get; }
        public int OrderID { set; get; }
        public int ItemID { set; get; }
        public int Quantity { set; get; }
        public int Amount { set; get; }
    }
}
