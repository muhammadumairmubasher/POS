using System;
namespace POS_BO
{
    public class Receipt
    {
        public int ReceiptNo { set; get; }
        public DateTime ReceiptDate { set; get; }
        public int OrderNo { set; get; }
        public int Amount { set; get; }
    }
}
