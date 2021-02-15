using System;
using Enums;

namespace Models.Island
{
    public class Island
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Some people charge for buying on their island
        public int? SalesTax { get; set; }
        // Who owns the island
        public Guid OwnerId { get; set; }
        // Separate from Region as players can change Island Hemisphere regardless of geo location
        public Hemisphere Hemisphere { get; set; }
        // Real world gameplay region
        public Region Region { get; set; }
    }
}