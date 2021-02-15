using System;
using Enums;

namespace Models.Stalk
{
    // Could probably pick a better name for this but whatever
    public class Stalk
    {
        public Guid Id { get; set; }
        // What island has this price
        public Guid IslandId { get; set; }
        // Prices are set 2x a day, morning and afternoon
        public Meridian Meridian { get; set; }
        // The price at which timmy and tommy will buy turnips
        public int ShopPrice { get; set; }
        // Date of the price
        public DateTime Date { get; set; }
        // Who observed this value
        public Guid EnteredBy { get; set; }
    }
}