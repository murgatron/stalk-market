using System;

namespace Models.Buy
{
    public class Buy
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public Guid OnIsland { get; set; }
        public Guid Buyer { get; set; }
        public int Quantity { get; set; }
        public DateTime BuyDate { get; set; }
    }
}