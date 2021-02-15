using System;
using Enums;

namespace Models.Transaction
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public TransactionType Type { get; set; }
        public Guid OnIsland { get; set; }
        public Guid Villager { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}