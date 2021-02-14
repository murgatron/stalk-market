using System;

namespace Models.Island
{
    // Who plays ACNH anyway? 
    public enum Region
    {
        NA,
        EU,
        LATAM,
        OCE,
        RU,
        CN,
        SEA
    }

    public enum Hemisphere
    {
        North,
        South
    }

    public class Island
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Some people charge for buying on their island
        public int? PurchaseTax { get; set; }
        // Who owns the island
        public Guid Owner { get; set; }
        // Separate from Region as players can change Island Hemisphere regardless of geo location
        public Hemisphere Hemisphere { get; set; }
        // Real world gameplay region
        public string Region { get; set; }
    }
}