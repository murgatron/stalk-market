using System;
using Enums;

namespace Models.CreateIsland
{
    public class CreateIsland
    {
        public string Name { get; set; }
        // Some people charge for buying on their island
        public int? SalesTax { get; set; }
        // Who owns the island
        public Guid Owner { get; set; }
        // Separate from Region as players can change Island Hemisphere regardless of geo location
        public Hemisphere Hemisphere { get; set; }
        // Real world gameplay region
        public Region Region { get; set; }
    }
}