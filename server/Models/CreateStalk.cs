using System;
using Enums;

namespace Models.CreateStalk
{
    // Could probably pick a better name for this but whatever
    public class CreateStalk
    {
        public Guid IslandId { get; set; }
        public Meridian Meridian { get; set; }
        public int ShopPrice { get; set; }
        public DateTime Date { get; set; }
        public Guid EnteredBy { get; set; }
    }
}