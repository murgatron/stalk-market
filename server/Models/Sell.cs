using System;

namespace Models.Sell
{
    public class Sell
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public Guid OnIsland { get; set; }
        public Guid Seller { get; set; }
        public int Quantity { get; set; }
        public DateTime SellDate { get; set; }
    }
}