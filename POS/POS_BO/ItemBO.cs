using System;
namespace POS_BO
{
    public class ItemBO
    {
        public int ItemID { set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public DateTime CreationDate { set; get; } = DateTime.Today;        
    }
}
