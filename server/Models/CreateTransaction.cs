using System;
using Enums;

namespace Models.CreateTransaction
{
    public class CreateTransaction
    {
        public int Price { get; set; }
        public TransactionType Type { get; set; }
        public Guid OnIsland { get; set; }
        public Guid VillagerId { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}